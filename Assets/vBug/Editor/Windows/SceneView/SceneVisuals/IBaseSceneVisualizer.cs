//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using UnityEditor;
using Frankfort.VBug.Internal;

namespace Frankfort.VBug.Editor
{
    public interface IBaseSceneVisualizer
    {
        SceneVisualState state { get; set; }

        void Dispose();

        void DrawSlice(int frameNumber);

        void RenderMouseOverSceneView(SceneView view);

        void RenderAnySceneView(SceneView view);

        void OnDatabaseUpdated();
    }
    
}
