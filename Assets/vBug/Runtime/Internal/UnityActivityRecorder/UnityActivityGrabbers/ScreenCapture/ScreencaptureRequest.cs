//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using UnityEngine;
using System;
using System.Collections;

namespace Frankfort.VBug.Internal
{
    public class ScreenCaptureRequest : IAbortableWorkObject
    {
        public class RenderLayer
        {
            public RenderTexture sourceTexture;
            public Color32[] colorBuffer;
            public byte[] byteBuffer;

            public int destinationWidth { get; private set; }
            public int destinationHeight { get; private set; }
            
            private Texture2D _destTexture;
            public Texture2D destTexture {
                get { return _destTexture; }
                set {
                    _destTexture = value;
                    if (_destTexture != null) {
                        destinationWidth = _destTexture.width;
                        destinationHeight = _destTexture.height;
                    } else {
                        destinationWidth = destinationHeight = 0;
                    }
                }
            }
            
            public void Dispose()
            {
                if (destTexture != null)
                    TexturePool.StoreTexture2D(destTexture);

                byteBuffer = null;
                colorBuffer = null;
                sourceTexture = null;
                destTexture = null;
            }
        }

        public enum State
        {
            idle,
            awaitingCapture,
            getBytes,
            getColors,
            complete
        }

        public State state;
        public int frameNumber;


        public Camera[] renderCams;
        public int screenWidth;
        public int screenHeight;
        public int resultWidth;
        public int resultHeight;
        public Vector2 scale;
        public ScreenCaptureQuality quality;

        public RenderLayer[] renderLayers;
        public int scaleDown = 1;
        
        public bool isAborted { get; set; }

        public ScreenCaptureRequest(int frameNumber, int resultWidth, int resultHeight, Vector2 scale, ScreenCaptureQuality quality)
        {
            this.frameNumber = frameNumber;
            this.screenWidth = Screen.width;
            this.screenHeight = Screen.height;
            this.resultWidth = resultWidth;
            this.resultHeight = resultHeight;
            this.scale = scale;
            this.quality = quality;
        }

        public void SetCameras(Camera[] renderCams) {
            if (renderCams == null)
                return;

            this.renderCams = renderCams;
            this.renderLayers = new RenderLayer[renderCams.Length];
            for (int i = 0; i < renderCams.Length; i++)
                renderLayers[i] = new RenderLayer();
        }

        public void Dispose(){
            if (isAborted)
                return;
            isAborted = true;
            
            if (renderLayers != null){
                foreach (RenderLayer layer in renderLayers)
                    layer.Dispose();
            }

            renderCams = null;
            renderLayers = null;
        }
    }
}