//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using System.Collections.Generic;
using UnityEngine;
using Frankfort.VBug;
using Frankfort.VBug.Internal;
using System.Threading;
using System.Runtime.InteropServices;
using UnityEditor;

namespace Frankfort.VBug.Editor
{
    public static class VerticalSliceDatabase
    {
        public class VerticalSlicePointer
        {
            public enum State {
                idle,
                requested,
                loading,
                ready,
                failed
            }

            public int frameNumber;
            public State state = State.idle;
            public double requestTimeStamp;
            public string path;
            public VerticalActivitySlice slice;

            public VerticalSlicePointer(int frameNumber, string path)
            {
                this.frameNumber = frameNumber;
                this.path = path;
            }

            public void Dispose()
            {
                if (slice != null)
                    slice.Dispose();

                slice = null;
                path = null;
            }

            public void Prune() {
                if (slice != null)
                    slice.Dispose();

                slice = null;
                state = State.idle;
                requestTimeStamp = 0;
            }
        }


        public static bool isInitialized { get; private set; }
        public static int minRange { get; private set; }
        public static int maxRange { get; private set; }

        private static int identifier = int.MinValue;
        private static bool delegatesHooked = false;
        private static int verticalSliceLoadCount = 0;
        private static Dictionary<int, VerticalSlicePointer> verticalSlicePointers = new Dictionary<int, VerticalSlicePointer>();
        private static List<VerticalActivitySlice> loadBundle = new List<VerticalActivitySlice>();
        
        //--------------- Threading --------------------
        private static Thread loaderThread;
        private static double threadStartTimeStamp;
        private static bool readyForNotification = false;
        //--------------- Threading --------------------
		

        public static void Reset() {
            minRange = 0;
            maxRange = 0;

            TerminateLoaderThread();
            foreach (KeyValuePair<int, VerticalSlicePointer> pair in verticalSlicePointers)
                pair.Value.Dispose();

            if (loadBundle != null) {
                foreach (VerticalActivitySlice slice in loadBundle)
                    slice.Dispose();
            }

            verticalSlicePointers.Clear();
            loadBundle.Clear();
            ReleaseDelegates();
            isInitialized = false;

            Resources.UnloadUnusedAssets();
            GC.Collect();
        }








        //--------------------------------------- GET SLICES --------------------------------------
        //--------------------------------------- GET SLICES --------------------------------------
        #region GET SLICES



        public static VerticalActivitySlice GetSlice(int frameNumber, bool requestLoading = false) {
            if (!isInitialized)
                return null;

            if (!verticalSlicePointers.ContainsKey(frameNumber))
                return null;

            VerticalSlicePointer pointer = verticalSlicePointers[frameNumber];
            if (pointer.state == VerticalSlicePointer.State.ready) {
                if (pointer.slice != null)
                    return pointer.slice;
            } else if (requestLoading && pointer.state == VerticalSlicePointer.State.idle) {
                AddLoadRequest(frameNumber);
            }
            return null;
        }



        public static bool PresentAndLoading(int frameNumber) {
            if (!isInitialized)
                return false;

            if (!verticalSlicePointers.ContainsKey(frameNumber))
                return false;

            return verticalSlicePointers[frameNumber].state != VerticalSlicePointer.State.failed;
        }
        #endregion
        //--------------------------------------- GET SLICES --------------------------------------
        //--------------------------------------- GET SLICES --------------------------------------










        //--------------------------------------- SET POINTER --------------------------------------
        //--------------------------------------- SET POINTER --------------------------------------
        #region SET POINTER

        public static void SetSliceLocations(string[] paths) {
            Reset();
            HookDelegates();

            if (paths == null || paths.Length == 0)
                return;

            int i = paths.Length;
            while (--i > -1)
                AddVerticalSlicePointer(paths[i]);

            isInitialized = true;
            vBugWindowMediator.NotifySessionChange(minRange, identifier);
        }


        public static void AddVerticalSlicePointer(string path) {
            if (string.IsNullOrEmpty(path))
                return;

            int startIdx = path.LastIndexOf("/") + 1;
            int lastIdx = path.LastIndexOf(".");
            if (startIdx == -1 || lastIdx == -1 || lastIdx < startIdx)
                return;

            string fileName = path.Substring(startIdx, lastIdx - startIdx);
            int frameNumber = 0;

            if (!int.TryParse(fileName, out frameNumber))
                return;

            if (minRange == 0 || frameNumber < minRange)
                minRange = frameNumber;

            if (maxRange == 0 || frameNumber > maxRange)
                maxRange = frameNumber;

            verticalSlicePointers.Add(frameNumber, new VerticalSlicePointer(frameNumber, path));
        }

        #endregion
        //--------------------------------------- SET POINTER --------------------------------------
        //--------------------------------------- SET POINTER --------------------------------------












        //--------------------------------------- UPDATE --------------------------------------
        //--------------------------------------- UPDATE --------------------------------------
        #region UPDATE

        private static void HookDelegates() {
            if (delegatesHooked)
                return;

            delegatesHooked = true;
            EditorApplication.update += Update;
        }

        private static void ReleaseDelegates() {
            if (!delegatesHooked)
                return;

            delegatesHooked = false;
            EditorApplication.update -= Update;
        }


        private static void Update() {
            PruneOutdatedSlices();
            NotifyBundleReady();
        }

        #endregion
        //--------------------------------------- UPDATE --------------------------------------
        //--------------------------------------- UPDATE --------------------------------------
			










        //--------------------------------------- LOADER THREAD --------------------------------------
        //--------------------------------------- LOADER THREAD --------------------------------------
        #region LOADER THREAD

        /// <summary>
        /// A request never comes alone. Once a missing frame is requested, a whole bunch of frames (called a bundle) is loaded because you can be sertain they are needed anyways.
        /// </summary>
        /// <param name="frameNumber"></param>
        private static void AddLoadRequest(int frameNumber) {
            if (frameNumber < minRange || frameNumber > maxRange)
                return;

            int halfRange = Mathf.Max(1, vBugEditorSettings.BackgroundLoadTheadBundleSize / 2);
            int startRange = frameNumber - halfRange;
            int endRange = frameNumber + halfRange;

            foreach (KeyValuePair<int, VerticalSlicePointer> pair in verticalSlicePointers) {
                if (pair.Key >= startRange && pair.Key < endRange && pair.Value.state == VerticalSlicePointer.State.idle) {
                    pair.Value.state = VerticalSlicePointer.State.requested;
                    pair.Value.requestTimeStamp = vBugEnvironment.GetUnixTimestamp();
                }
            }

            InitLoaderThread();
        }


        private static void InitLoaderThread() {
            if (loaderThread != null)
                return;

            loaderThread = new Thread(HandleThreadedLoading);
            loaderThread.IsBackground = true;
            loaderThread.Priority = System.Threading.ThreadPriority.BelowNormal;
            threadStartTimeStamp = vBugEnvironment.GetUnixTimestamp();
            loaderThread.Start();
        }


        private static void TerminateLoaderThread()
        {
            if (loaderThread != null && loaderThread.IsAlive && loaderThread.ThreadState == ThreadState.Running) {
                loaderThread.Interrupt();
                loaderThread.Join(100);
                if (vBugEditorSettings.DebugMode)
                    Debug.LogWarning("Close VerticalSliceDatabase thread");
            }
            loaderThread = null;
        }


        private static void HandleThreadedLoading() {
            double myStartTimeStamp = threadStartTimeStamp;

            while (isInitialized) {    
                if (threadStartTimeStamp != myStartTimeStamp) {
                    if (vBugEditorSettings.DebugMode)
                        Debug.LogError("Timestamps do not match! Editor windows where reinitialized while this thread remained active..." );
                    
                    break;
                }

                VerticalSlicePointer[] unProcessed = GetRequestedPointers(vBugEditorSettings.BackgroundLoadTheadBundleSize);
                if (unProcessed.Length > 0) {

                    readyForNotification = false;
                    foreach (VerticalSlicePointer pointer in unProcessed) {
                        lock (pointer) {
                            
                            //--------------- Load --------------------
                            pointer.state = VerticalSlicePointer.State.loading;
                            pointer.slice = IOEditorHelper.LoadVBugSliceFromDisk(pointer.path);
                            //--------------- Load --------------------

                            if (pointer.slice == null) {
                                pointer.state = VerticalSlicePointer.State.failed; //back to requested... lets wait for it to be ready!
                                if (vBugEditorSettings.DebugMode)
                                    Debug.LogError("pointer.slice == null @ " + pointer.frameNumber + " [" + pointer.path + "]");

                            } else {
                                pointer.state = VerticalSlicePointer.State.ready;
                                verticalSliceLoadCount++;
                                lock (loadBundle)
                                    loadBundle.Add(pointer.slice);
                            }
                        }
                    }
                    readyForNotification = true;
                }

                //TODO: find a way to notify windows within the main-thread.
                Thread.Sleep(vBugEditorSettings.BackgroundLoadThreadSleepTime);
            }

            if (vBugEditorSettings.DebugMode)
                Debug.Log("vBugEditor: VerticalSliceDatabase LoaderThread terminated!");
        }



        private static VerticalSlicePointer[] GetRequestedPointers(int bundleSize) {
            List<VerticalSlicePointer> result = new List<VerticalSlicePointer>();

            lock (verticalSlicePointers) {
                foreach (KeyValuePair<int, VerticalSlicePointer> pair in verticalSlicePointers) {
                    if (pair.Value.state == VerticalSlicePointer.State.requested)
                        result.Add(pair.Value);
                }
            }

            int currentFrame = vBugWindowMediator.currentFrameNumber;
            result.Sort((a, b) => Mathf.Abs(a.frameNumber - currentFrame).CompareTo(Mathf.Abs(b.frameNumber - currentFrame)));
            if (result.Count > bundleSize)
                result.RemoveRange(bundleSize, result.Count - bundleSize);

            return result.ToArray();
        }



        private static void NotifyBundleReady() {
            if (loadBundle == null || loadBundle.Count == 0)
                return;

            if (loadBundle.Count >= vBugEditorSettings.BackgroundLoadTheadBundleSize || (loadBundle.Count > 0 && readyForNotification)) {
                readyForNotification = false;

                VerticalActivitySlice[] notify = null;
                lock (loadBundle) {
                    notify = loadBundle.ToArray();
                    loadBundle.Clear();
                }

                vBugWindowMediator.NotifyVerticalSliceBundleLoaded(notify);
            }
        }

        #endregion
        //--------------------------------------- LOADER THREAD --------------------------------------
        //--------------------------------------- LOADER THREAD --------------------------------------










        //--------------------------------------- PRUNE --------------------------------------
        //--------------------------------------- PRUNE --------------------------------------
        #region PRUNE


        private static void PruneOutdatedSlices() {
            if (!isInitialized || verticalSliceLoadCount < vBugEditorSettings.VerticalSliceCacheMax)
                return;

            if (verticalSlicePointers == null || verticalSlicePointers.Count == 0)
                return;

            //--------------- Find ready --------------------
            List<VerticalSlicePointer> ready = new List<VerticalSlicePointer>();
            lock (verticalSlicePointers) {
                foreach (KeyValuePair<int, VerticalSlicePointer> pair in verticalSlicePointers) {
                    if (pair.Value.state == VerticalSlicePointer.State.ready)
                        ready.Add(pair.Value);
                }
            } 
            //--------------- Find ready --------------------


            //--------------- Sort by timestamp --------------------
            if (ready.Count == 0)
                return;

            int halfSaveZone = vBugEditorSettings.VerticalSliceCacheSafezone / 2;
            int saveZoneMin = vBugWindowMediator.currentFrameNumber - halfSaveZone;
            int saveZoneMax = vBugWindowMediator.currentFrameNumber + halfSaveZone;

            ready.Sort((a, b) => a.requestTimeStamp.CompareTo(b.requestTimeStamp));

            int iMax = Mathf.Max(0, ready.Count - vBugEditorSettings.VerticalSliceCacheMax);
            if (iMax > 0) {
                for (int i = 0; i < iMax; i++) {
                    VerticalSlicePointer pointer = ready[i];
                    if (pointer.frameNumber >= saveZoneMin && pointer.frameNumber <= saveZoneMax)
                        continue;

                    pointer.Prune();
                    verticalSliceLoadCount--;
                }
            }
            //--------------- Sort by timestamp --------------------
        }


        #endregion
        //--------------------------------------- PRUNE --------------------------------------
        //--------------------------------------- PRUNE --------------------------------------



    }
}
