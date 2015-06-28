//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using UnityEngine;
using System;
using Frankfort.VBug.Internal;


namespace Frankfort.VBug.Editor
{
    public static class vBugEditorSettings
    {
        public static bool DebugMode = false;
        public static bool MultithreadedLoading = true;
        public static int VerticalSliceCacheMax = 3000;
        public static int VerticalSliceCacheSafezone = 2000;
        public static int BackgroundLoadTheadBundleSize = 50;
        public static int BackgroundLoadThreadSleepTime = 10;
        
        public static int CleanMemoryTimelineInterval = 1000;
        public static int PlaybackCoreNavSearhRange = 60; //1 sec

        public static int PlaybackMeshGhostLength = 1000;
        public static int PlaybackMeshBonesInterval = 3;
        public static Color PlaybackMeshBoundingBoxColor = new Color(1f, 0.75f, 0.5f);
        public static int PlaybackRenderLayer = 31;

        public static int PlaybackMeshSearchRange = 200;
        public static int PlaybackParticleSearchRange = 150;

        public static int PlaybackSystemDefaultSearchRange = 30;
        public static int PlaybackSystemMemorySearchRange = 250;

        public static int PlaybackOverlaySearchRange = 30;
        public static int PlaybackMaterialSearchRange = 100;


        public static int PlaybackHierarchySearchRange = 30;
        public static int PlaybackHierarchyEOLBirthSearchRange = 10;
    }
}