//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;
using System.Collections;




namespace Frankfort.VBug.Internal {

    [AddComponentMenu("")]
    public class WorkloadDistributionManager : vBugHiddenUniqueComponent<WorkloadDistributionManager>
    {
        public delegate bool WorkLoadExecutor(IAbortableWorkObject arg);
        public delegate void WorkLoadComplete(IAbortableWorkObject arg);


        private class AsyncWorkloadData
        {
            public WorkloadExecutorType executionType;
            public WorkLoadExecutor executor;
            public IAbortableWorkObject arg;
            public bool complete;
            public WorkLoadComplete onCompleteCallback;

            public AsyncWorkloadData(WorkloadExecutorType executionType, WorkLoadExecutor executor, IAbortableWorkObject arg, WorkLoadComplete onCompleteCallback)
            {
                this.executionType = executionType;
                this.executor = executor;
                this.arg = arg;
                this.onCompleteCallback = onCompleteCallback;
            }
        }













        //--------------------------------------- STATIC --------------------------------------
        //--------------------------------------- STATIC --------------------------------------
        #region STATIC


        private static List<AsyncWorkloadData> finishedThreadObjects = new List<AsyncWorkloadData>();


        public static void AddWork(WorkloadExecutorType executionType, WorkLoadExecutor executor, IAbortableWorkObject arg, WorkLoadComplete onCompleteCallback) {
            SetHelper();
            helper.AddToWorkList(executionType, executor, arg, onCompleteCallback);
        }


        #endregion
        //--------------------------------------- STATIC --------------------------------------
        //--------------------------------------- STATIC --------------------------------------
				













        //--------------------------------------- MONOBEHAVIOUR --------------------------------------
        //--------------------------------------- MONOBEHAVIOUR --------------------------------------
        #region MONOBEHAVIOUR


        private List<AsyncWorkloadData> workList = new List<AsyncWorkloadData>();
        private List<Thread> workerThreads = new List<Thread>();
        private bool isAlive;
        private bool threadsInitialized = false;

        private void Awake()
        {
            isAlive = true;
        }


        //--------------- ABORT RUNNING THREADS --------------------
        protected override void OnApplicationQuit(){
 	        base.OnApplicationQuit();
            AbortRunningThreads();
        }

        private void OnDestroy() {
            AbortRunningThreads();
            isAlive = false;
        }

        private void AbortRunningThreads()
        {
            if (workerThreads.Count > 0) {
                foreach (Thread worker in workerThreads) {
                    if (worker != null && worker.IsAlive && worker.ThreadState != ThreadState.Stopped) {
                        worker.Interrupt();
                        worker.Join(100);

                        if (vBug.settings.general.debugMode)
                            Debug.LogWarning("Close " + this.GetType().Name + " thread");
                    }
                }
            }

            workerThreads.Clear();
            threadsInitialized = false;
        }


        private void InitThreadPool(int threadCount) {
            if (threadsInitialized)
                return;

            AbortRunningThreads();
            if (threadCount == -1)
                threadCount = Mathf.Max(1, SystemInfo.processorCount - 1);

            while (--threadCount > -1) {
                Thread thread = new Thread(UpdateWorkerThread);
                thread.Start();
                workerThreads.Add(thread);
            
                if (vBug.settings.general.debugMode)
                    Debug.LogWarning("WorkloadDistibutionManager-> thread created: " + thread.ManagedThreadId);
            }

            threadsInitialized = true;
        }
        //--------------- ABORT RUNNING THREADS --------------------



        public void AddToWorkList(WorkloadExecutorType executionType, WorkLoadExecutor executor, IAbortableWorkObject arg, WorkLoadComplete onCompleteCallback)
        {
            if (vBug.settings.general.multiThreading) {
                InitThreadPool(vBug.settings.general.workerThreadCount);
            } else {
                executionType = WorkloadExecutorType.update;
            }

            workList.Add(new AsyncWorkloadData(executionType, executor, arg, onCompleteCallback));
        }






        //--------------- WORKLOAD EXECUTION LOOPS --------------------
        /// <summary>
        /// All cycles have their own Thread and can be executed in parallel, unlike the Update and LateUpdate routines
        /// </summary>
        /// <param name="workArg"></param>
        private void Update()
        {
            if (finishedThreadObjects != null && finishedThreadObjects.Count > 0) {
                for (int i = 0; i < finishedThreadObjects.Count; i++) {
                    if (finishedThreadObjects[i].onCompleteCallback != null)
                        finishedThreadObjects[i].onCompleteCallback(finishedThreadObjects[i].arg);
                }
                finishedThreadObjects.Clear();
            }

            ExecuteNextItemSequential(WorkloadExecutorType.update);
            if (Time.timeScale <= 0f) //fixedUpdate not working if timescale is set to 0!
                ExecuteNextItemSequential(WorkloadExecutorType.fixedUpdate);
        }
        
        
        private void LateUpdate() {
            ExecuteNextItemSequential(WorkloadExecutorType.lateUpdate);
        }
        
        private void FixedUpdate(){
            ExecuteNextItemSequential(WorkloadExecutorType.fixedUpdate);
        }

        private void UpdateWorkerThread() {
            while (isAlive) {
                Thread.Sleep(300);
                ExecuteNextItemSequential(WorkloadExecutorType.thread, false);
            }
        }


        private void ExecuteNextItemSequential(WorkloadExecutorType workloadExecutorType, bool isMainThread = true) {
            if (workList == null || workList.Count == 0)
                return;

            List<AsyncWorkloadData> bundle = new List<AsyncWorkloadData>();

            //--------------- Get from worklist --------------------
            lock (workList) {
                int i = workList.Count;
                while (--i > -1) {
                    if (workList[i] != null && workList[i].executionType == workloadExecutorType) {
                        bundle.Add(workList[i]);
                        workList.RemoveAt(i);
                    }
                }
            }
            //--------------- Get from worklist --------------------

            //--------------- Execute threadsafe --------------------
            if (bundle.Count > 0) {
                foreach (AsyncWorkloadData data in bundle)
                    HandleNextItem(data, isMainThread);
            }
            //--------------- Execute threadsafe --------------------
        }

        
        private static void HandleNextItem(AsyncWorkloadData data, bool isMainThread) {
            try {                
                if (data.arg == null || !data.arg.isAborted)
                {
                    bool succes = false;
                    if (data.executor != null)
                        succes = data.executor(data.arg);
            
                    //MAKE SURE THIS GETS EXECUTED ON THE MAIN THREAD!
                    if (succes && data.onCompleteCallback != null) {
                        if (isMainThread) {
                            data.onCompleteCallback(data.arg);
                        } else {
                            lock (finishedThreadObjects)
                                finishedThreadObjects.Add(data);
                        }
                    }
                }

            } catch (Exception e) {
                if (vBug.settings.general.debugMode)
                    Debug.LogError(e.Message + e.StackTrace);
            }
        }
        //--------------- WORKLOAD EXECUTION LOOPS --------------------



        #endregion
        //--------------------------------------- MONOBEHAVIOUR --------------------------------------
        //--------------------------------------- MONOBEHAVIOUR --------------------------------------


    }
}