//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Frankfort.VBug.Internal
{
    public static class TexturePool
    {
        private const int maxByteBuffers = 1024;
        private const int maxTextures2D = 64;
        private const int maxRenderTextures = 4;

        private static List<Texture2D> texture2DBuffers = new List<Texture2D>();
        
        //--------------- Dispose --------------------
        public static void PruneCache()
        {
            if (texture2DBuffers == null || texture2DBuffers.Count == 0)
                return;

            if (Application.isPlaying)
            {
                foreach (Texture2D texture in texture2DBuffers)
                    UnityEngine.Object.Destroy(texture);
            } else { 
                foreach (Texture2D texture in texture2DBuffers)
                    UnityEngine.Object.DestroyImmediate(texture);
            }

            if (vBug.settings.general.debugMode)
                Debug.Log("vBug TexturePool cleared: " + texture2DBuffers.Count);

            texture2DBuffers.Clear();
        }
        //--------------- Dispose --------------------
			




        //--------------- TEXTURE 2D --------------------
        public static Texture2D GetTexture2D(int width, int height, bool linear, RenderTextureFormat rtMatchFormat = RenderTextureFormat.Default)
        {
            Texture2D result = null;
            int i = texture2DBuffers.Count;
            while (--i > -1){
                if (texture2DBuffers[i] == null){
                    texture2DBuffers.RemoveAt(i);
                }
            }

            TextureFormat format = GetBest2DFormat(rtMatchFormat);
            int idx = texture2DBuffers.FindIndex(item => item.width == width && item.height == height && item.format == format);
            if (idx != -1){
                result = texture2DBuffers[idx];
                texture2DBuffers.RemoveAt(idx);
            }

            if (result == null) {
                result = new Texture2D(width, height, format, false, linear);
                result.name = "vBug_PoolTexture";
                result.filterMode = FilterMode.Point;
                result.anisoLevel = 0;
            }

            return result;
        }



        private static TextureFormat GetBest2DFormat(RenderTextureFormat formatRT) {
            switch (formatRT) {
                case RenderTextureFormat.Default:
                case RenderTextureFormat.DefaultHDR:
                    return TextureFormat.ARGB32;

                default:
                    return formatRT.ToString().Contains("A") ? TextureFormat.ARGB32 : TextureFormat.RGB24;
            }
        }



        public static void StoreTexture2D(Texture2D texture)
        {
            if (texture == null || texture2DBuffers.Contains(texture))
                return;

            if (texture2DBuffers.Count > maxTextures2D)
            {
                if (vBug.settings.general.debugMode)
                    Debug.Log("Max Texture2D's reached @" + texture2DBuffers.Count);

                if (Application.isPlaying){
                    UnityEngine.Object.Destroy(texture2DBuffers[0]);
                }else{
                    UnityEngine.Object.DestroyImmediate(texture2DBuffers[0]);
                }
                texture2DBuffers.RemoveAt(0);
            }
            texture2DBuffers.Add(texture);
        }
        //--------------- TEXTURE 2D --------------------
    }
}
