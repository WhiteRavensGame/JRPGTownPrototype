﻿//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Frankfort.VBug.Internal;

namespace Frankfort.VBug.Editor
{
    public class BasePlaybackOverlay
    {
        [HideInInspector]
        public bool doDrawMainContainer;
        [HideInInspector]
        public bool doDrawSubContainer;
        [HideInInspector]
        public bool doDrawQuads;
        [HideInInspector]
        public bool requiresScreenCapture;


        protected bool showAlpha;
        protected List<GameObject> allQuads = new List<GameObject>();
        
        protected GameObject CreateQuad()
        {
            Material material = new Material(VisualResources.GetGUIMaterial());
            material.hideFlags = HideFlags.HideAndDontSave;

            
            GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
            quad.layer = vBugEditorSettings.PlaybackRenderLayer;

            Renderer renderer = quad.GetComponent<Renderer>();
            if (renderer != null) {
                renderer.sharedMaterial = material;

#if UNITY_4_6
                renderer.castShadows = false;
#else
                renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
#endif
                renderer.receiveShadows = false;
                renderer.useLightProbes = false;
            }

            GameObject.DestroyImmediate(quad.GetComponent<MeshCollider>());
            Frankfort.VBug.Internal.GameObjectUtility.SetHideFlagsRecursively(quad);
            
            allQuads.Add(quad);
            return quad;
        }


        public virtual void DisposeSceneVisuals()
        {
            DestroyAllQuads();
        }

        public virtual void Dispose()
        {
            DestroyAllQuads();
            //Debug.Log("BasePlaybackOverlay Dispose called! " + this.GetType().FullName); 
        }

        protected virtual void DestroyAllQuads()
        {
            if (allQuads != null && allQuads.Count > 0)
            {
                int i = allQuads.Count;
                while (--i > -1)
                {
                    GameObject quad = allQuads[i];
                    if (quad != null) {
                        Renderer renderer = quad.GetComponent<Renderer>();
                        if (renderer != null)
                            UnityEngine.GameObject.DestroyImmediate(renderer.sharedMaterial);
                        
                        UnityEngine.GameObject.DestroyImmediate(quad);
                    }
                }
                allQuads.Clear();
            }
        }

        protected void SetQuadColor(GameObject quad, Color color){
            Renderer renderer = quad.GetComponent<Renderer>();
            if (renderer != null)
                renderer.sharedMaterial.SetColor("_Color", color);
        }

        public virtual bool DrawMainContainer(Rect mainRect, int currentFrame, vBugBaseWindow parent)
        { throw new NotImplementedException(); }

        public virtual void DrawQuads(Transform parent, Vector3 localScale, VerticalActivitySlice slice)
        { throw new NotImplementedException(); }

        public virtual bool DrawSubContainer(int currentFrame, vBugBaseWindow parent)
        { throw new NotImplementedException(); }

        public virtual void DrawSettingsLayout(VerticalActivitySlice slice, bool showAlpha)
        {
            this.showAlpha = showAlpha;
        }

        public virtual void InitCurrentFrame()
        { }

        public virtual void NotifyTimelineChange(int newFrame)
        { }
        
        public virtual void NotifySessionChange(int startFrame)
        { } 
    }
}
