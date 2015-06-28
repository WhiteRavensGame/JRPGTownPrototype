//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using UnityEngine;
using System.Collections.Generic;

namespace Frankfort.VBug.Internal {

    [AddComponentMenu("")]
    public class DebugLogsGrabber : BaseActivityGrabber<DebugLogSnapshot>
    {
        private List<DebugLogCall> callQueue = new List<DebugLogCall>();

        private void OnEnable()
        {
#if UNITY_4_6
            Application.RegisterLogCallback(CaptureDebugLogThreaded);
#else
            Application.logMessageReceived += CaptureDebugLogThreaded;
            Application.logMessageReceivedThreaded += CaptureDebugLogThreaded;
#endif
        }


        private void OnDisable()
        {
#if UNITY_4_6
            Application.RegisterLogCallback(null);
#else
            Application.logMessageReceived -= CaptureDebugLogThreaded;
            Application.logMessageReceivedThreaded -= CaptureDebugLogThreaded;
#endif
        }

        
        protected override void GrabResultEndOfFrame()
        {
            base.GrabResultEndOfFrame();
            if (resultReadyCallback != null)
                resultReadyCallback(currentFrame, new DebugLogSnapshot(callQueue.ToArray()), 0);

            callQueue.Clear();
        }

        public override void AbortAndPruneCache()
        {
            base.AbortAndPruneCache();
            callQueue.Clear();
        }

        private void CaptureDebugLogThreaded(string logString, string stackTrace, LogType type)
        {
            if (vBugLogger.Contains(logString))
                return;

            lock (callQueue) {
                callQueue.Add(new DebugLogCall(type, logString, stackTrace));
            }
        }
    }
}