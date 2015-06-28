//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngineInternal;
using System.Runtime.InteropServices;
using System.Reflection;
using System;
using Frankfort.VBug.Editor;


namespace Frankfort.VBug.Internal
{

    [AddComponentMenu("")]
    public class ScreenGrabber : BaseActivityGrabber<ScreenCaptureSnapshot>
    {
        private ScreenCaptureRequest currentRequest;
        private bool running = false;
        private int uiLayer;
        private Camera uiCam;

        private RenderTexture outputRT;
        private RenderTexture redirectRT;


        protected override void Start()
        {
            base.Start();
            uiLayer = 1 << LayerMask.NameToLayer("UI");
            StartCoroutine(OnEndOfFrame());
        }

        public override void AbortAndPruneCache() {
            base.AbortAndPruneCache();
            if (!running)
                return;

            if (currentRequest != null)
                currentRequest.Dispose();

            if (outputRT != null)
                Destroy(outputRT);

            if (redirectRT != null)
                Destroy(redirectRT);

            if (uiCam != null)
                Destroy(uiCam.gameObject);

            currentRequest = null;
            outputRT = null;

            running = false;
        }



        public override bool GrabActivity(int currentFrame)
        {
            if (base.GrabActivity(currentFrame))
            {
                //--------------- Check untiy licence first --------------------
                //TODO: Check  &
                if (vBug.settings.recording.screenCapture.captureMethod != ScreenCaptureMethod.endOfFrame && !SystemInfo.supportsRenderTextures) {
                    Debug.LogWarning("User does not have a Pro-licence, therefore '" + vBug.settings.recording.screenCapture.captureMethod + "' capturing is not supported... vBug will now switch to 'EndOfFrame' capturing, this may cause additional performance costs.");
                    vBug.settings.recording.screenCapture.captureMethod = ScreenCaptureMethod.endOfFrame;
                }
                //--------------- Check untiy licence first --------------------
                
                
                //--------------- Calculate optimal texturesize --------------------
                int max = Math.Min(Math.Max(Screen.height, Screen.width), vBug.settings.recording.screenCapture.maxScreenCaptureSize);
                int resultWidth = Screen.width;
                int resultHeight = Screen.height;

                if (resultWidth > resultHeight) {
                    resultWidth = max;
                    resultHeight = (int)((float)resultHeight * ((float)max / (float)Screen.width));
                } else if (resultHeight > resultWidth) {
                    resultHeight = max;
                    resultWidth = (int)((float)resultWidth * ((float)max / (float)Screen.height));
                }
                //--------------- Calculate optimal texturesize --------------------

                //--------------- POT --------------------
                if (vBug.settings.recording.screenCapture.cropMethod != ScreenCropMethod.none) {
                    resultWidth = vBugMathHelper.MakePowerOfTwo(resultWidth);
                    resultHeight = vBugMathHelper.MakePowerOfTwo(resultHeight);

                    if (resultWidth != resultHeight && vBug.settings.recording.screenCapture.cropMethod == ScreenCropMethod.squarePOT)
                        resultWidth = resultHeight = Mathf.Max(resultWidth, resultHeight);
                }
                //--------------- POT --------------------


                //--------------- Setup request --------------------
                Vector2 scale = new Vector2(
                    (float)resultWidth / (float)Screen.width,
                    (float)resultHeight / (float)Screen.height
                );
                currentRequest = new ScreenCaptureRequest(Time.frameCount, resultWidth, resultHeight, scale, vBug.settings.recording.screenCapture.quality);
                //--------------- Setup request --------------------

                switch (vBug.settings.recording.screenCapture.captureMethod) {
                    case ScreenCaptureMethod.redirectRender:
                        Init_Redirect(resultWidth, resultHeight);
                        break;
                    case ScreenCaptureMethod.endOfFrame:
                        Init_EOF();
                        break;
                    case ScreenCaptureMethod.jitRender:
                        Init_JIT(resultWidth, resultHeight);
                        break;
                }
                running = true;
                return true;
            }

            currentRequest = null;
            return false;
        }



        private void Init_EOF() {
            currentRequest.SetCameras(new Camera[] { Camera.main });
        }


        private void Init_Redirect(int outputWidth, int outputHeight) {
            InitRenderTexture(Screen.width, Screen.height, ref redirectRT);
            InitRenderTexture(outputWidth, outputHeight, ref outputRT);
            List<Camera> cameras = InitRenderTextureAndCameras();

            int i = cameras.Count;
            while (--i > -1) {
                Camera cam = cameras[i];
                if (cam.targetTexture != null && cameras[i].targetTexture != redirectRT) {
                    cameras.RemoveAt(i); //skipp camera's with non-vBug textures attached
                } else {
                    cam.targetTexture = redirectRT;
                }
            }
            currentRequest.SetCameras(new Camera[] { Camera.main });
        }


        private void Init_JIT(int outputWidth, int outputHeight) {
            InitRenderTexture(outputWidth, outputHeight, ref outputRT);
            List<Camera> cameras = InitRenderTextureAndCameras();
            currentRequest.SetCameras(cameras.ToArray());
        }

        private void InitRenderTexture( int outputWidth, int outputHeight, ref RenderTexture rt){
            
            int depthRT = vBug.settings.recording.screenCapture.rtDepth;
            bool linearRT = vBug.settings.recording.screenCapture.rtLinearColorSpace;
            RenderTextureFormat formatRT = vBug.settings.recording.screenCapture.rtFormat;

            if (rt == null || rt.width != outputWidth || rt.height != outputHeight || rt.depth != depthRT || rt.format != formatRT) {
                if (rt != null)
                    Destroy(rt);

                rt = new RenderTexture(outputWidth, outputHeight, depthRT, formatRT, RenderTextureReadWrite.Linear);
            }

            if(depthRT > 0)
                rt.DiscardContents();
        }



        private List<Camera> InitRenderTextureAndCameras() {
            List<Camera> activeCams = new List<Camera>();

            if (vBug.settings.recording.screenCapture.jitRenderCaptureAllCameras) {

                //--------------- Add all cameras --------------------
                Camera[] cameras = GameObject.FindObjectsOfType<Camera>();
                foreach (Camera cam in cameras) {
                    if (CheckCam(cam))
                        activeCams.Add(cam);
                }

            } else {
                //--------------- Add manual selected camera's --------------------
                vBugJitCameraRecordable[] recordables = GameObject.FindObjectsOfType<vBugJitCameraRecordable>();
                if (recordables != null && recordables.Length > 0) {
                    foreach (vBugJitCameraRecordable rec in recordables) {
                        Camera cam = rec.gameObject.GetComponent<Camera>();
                        if (CheckCam(cam))
                            activeCams.Add(cam);
                    }
                }
            }

            RedirectUICanvas(activeCams, currentRequest);
            activeCams.Sort((a, b) => a.depth.CompareTo(b.depth));

            return activeCams;
        }





        private bool CheckCam(Camera cam) {
            return cam != null && cam.enabled && cam.gameObject.activeInHierarchy && !cam.name.Contains("vBug");
        }


        private void RedirectUICanvas(List<Camera> storeTo, ScreenCaptureRequest parentRequest) {
            Canvas[] canvasses = GameObject.FindObjectsOfType<Canvas>();
            
            foreach (Canvas canvas in canvasses) {
                if (!canvas.gameObject.activeSelf || !canvas.gameObject.activeInHierarchy || !canvas.enabled)
                    continue;

                if (canvas.renderMode == (RenderMode)0) {//4.6: ScreenSpaceOverlay | 5.0: Overlay;
                    canvas.worldCamera = GetUICamera();
                    canvas.renderMode = (RenderMode)1; //4.6: ScreenSpaceCamera | 5.0: OverlayCamera;

                } else if (canvas.worldCamera == null) {
                    canvas.worldCamera = GetUICamera();
                }

                if (!storeTo.Contains(canvas.worldCamera))
                    storeTo.Add(canvas.worldCamera);
            }
        }








        //--------------------------------------- INIT CAMERA's --------------------------------------
        //--------------------------------------- INIT CAMERA's --------------------------------------
        #region INIT CAMERA's
        
        
        private Camera GetUICamera() {
            if (uiCam == null) {

                GameObject camGO = new GameObject("vBug_UI-Canvas");
                uiCam = camGO.AddComponent<Camera>();
                uiCam.orthographic = true;
                uiCam.orthographicSize = 1f;
                uiCam.transparencySortMode = TransparencySortMode.Orthographic;

                uiCam.renderingPath = RenderingPath.VertexLit;
                uiCam.clearFlags = CameraClearFlags.Depth;
                uiCam.useOcclusionCulling = false;

                uiCam.cullingMask = uiLayer;
                uiCam.nearClipPlane = 0.1f;
                uiCam.farClipPlane = 10000f;
                uiCam.depth = GetHighestCameraDepth(uiCam);
                //GameObjectUtility.SetHideFlagsRecursively(uiCam.gameObject); //Hiding this camera causes the canvases not to be rendered when switching a scene
            }

            return uiCam;
        }




        private float GetHighestCameraDepth(Camera exclude) {
            if (Camera.allCameras == null)
                return 0;

            if (Camera.allCamerasCount == 1)
                return Camera.allCameras[0].depth;

            float highest = float.MinValue;
            foreach (Camera cam in Camera.allCameras) {
                if (cam == exclude)
                    continue;

                highest = Mathf.Max(highest, cam.depth);
            }

            return highest + 1;
        }
        
        #endregion
        //--------------------------------------- INIT CAMERA's --------------------------------------
        //--------------------------------------- INIT CAMERA's --------------------------------------
			











        //--------------------------------------- UPDATE LOOPS --------------------------------------
        //--------------------------------------- UPDATE LOOPS --------------------------------------
        #region UPDATE LOOPS

        private IEnumerator OnEndOfFrame() {
            while (isAlive) {
                yield return new WaitForEndOfFrame();
                ScreenCaptureMethod captureMethod = vBug.settings.recording.screenCapture.captureMethod;
                
                if (captureMethod == ScreenCaptureMethod.endOfFrame && currentRequest != null && !currentRequest.isAborted) {
                    GrabPixelsEndOfFrame();
                } else if (captureMethod == ScreenCaptureMethod.redirectRender) {

                    if (redirectRT != null) {
#if UNITY_4_6 && (UNITY_STANDALONE || UNITY_EDITOR) 
                        Graphics.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), redirectRT);
#else
                        Graphics.Blit(redirectRT, null as RenderTexture);//Blit to screen
#endif
                    }
                }
            }
        }


        //10 fps more then EndOfFrame
        private void LateUpdate() {
            ScreenCaptureMethod captureMethod = vBug.settings.recording.screenCapture.captureMethod;
            if (currentRequest != null && !currentRequest.isAborted) {
                if (captureMethod == ScreenCaptureMethod.jitRender) {
                    GrabJitRender();
                } else if (captureMethod == ScreenCaptureMethod.redirectRender) {
                    CaptureRedirectedRT();
                }
            }
        }

        
        #endregion
        //--------------------------------------- UPDATE LOOPS --------------------------------------
        //--------------------------------------- UPDATE LOOPS --------------------------------------
			







        //--------------------------------------- SCREENSHOT GRABBERS --------------------------------------
        //--------------------------------------- SCREENSHOT GRABBERS --------------------------------------
        #region SCREENSHOT GRABBERS

        private void CaptureRedirectedRT() {
            if (currentRequest == null || currentRequest.isAborted)
                return;

            if (currentRequest.renderLayers == null || currentRequest.renderLayers.Length == 0) {
                currentRequest.state = ScreenCaptureRequest.State.complete;
            } else {
                Graphics.Blit(redirectRT, outputRT); //scale down and set active
                currentRequest.renderLayers[0].sourceTexture = outputRT;
                currentRequest.renderLayers[0].destTexture = TexturePool.GetTexture2D(outputRT.width, outputRT.height, vBug.settings.recording.screenCapture.rtLinearColorSpace, outputRT.format);
                currentRequest.renderLayers[0].destTexture.ReadPixels(new Rect(0, 0, outputRT.width, outputRT.height), 0, 0, false);
                currentRequest.state = ScreenCaptureRequest.State.getColors;
                outputRT.DiscardContents();
            }

            HandleRequestState(currentRequest);
        }


        private void GrabPixelsEndOfFrame(){
            if (currentRequest == null || currentRequest.isAborted)
                return;

            if (currentRequest.renderLayers == null || currentRequest.renderLayers.Length == 0) {
                currentRequest.state = ScreenCaptureRequest.State.complete;
            } else {
                currentRequest.resultWidth = Screen.width;
                currentRequest.resultHeight = Screen.height; 
                currentRequest.renderLayers[0].destTexture = TexturePool.GetTexture2D(Screen.width, Screen.height, vBug.settings.recording.screenCapture.rtLinearColorSpace);
                currentRequest.renderLayers[0].destTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
                currentRequest.scaleDown = (int)(Mathf.Max(Mathf.Ceil((float)Screen.width / (float)currentRequest.resultWidth), Mathf.Ceil((float)Screen.height / (float)currentRequest.resultHeight)));
                currentRequest.state = ScreenCaptureRequest.State.getColors;
            }

            HandleRequestState(currentRequest);
        }


        private void GrabJitRender(){
            if (currentRequest == null || currentRequest.isAborted)
                return;

            if (currentRequest != null && currentRequest.renderCams != null)
            {
                int iMax = currentRequest.renderCams.Length;

                if (vBug.settings.recording.screenCapture.jitRenderLowQuality) {
                    RenderSettingsHelper.StoreRenderQuality();
                    RenderSettingsHelper.SetLowRenderQuality();
                }

                for (int i = 0; i < iMax; i++) {
                    ScreenCaptureRequest.RenderLayer layer = currentRequest.renderLayers[i];
                    Camera cam = currentRequest.renderCams[i];
                    if (layer == null || cam == null)
                        continue;
                    
                    layer.sourceTexture = outputRT;
                    cam.targetTexture = outputRT;
                    cam.RenderDontRestore();
                    ReadActiveToRenderLayer(layer, cam.rect);
                    cam.targetTexture = null;
                }

                if (vBug.settings.recording.screenCapture.jitRenderLowQuality)
                    RenderSettingsHelper.RestoreRenderQuality();

                currentRequest.state = ScreenCaptureRequest.State.getColors;
                HandleRequestState(currentRequest);
            
            } else {
                currentRequest.state = ScreenCaptureRequest.State.complete;
                HandleRequestState(currentRequest);
            }

            currentRequest = null;
        }



        private void ReadActiveToRenderLayer(ScreenCaptureRequest.RenderLayer layer, Rect camRect) {
            if (layer == null || layer.sourceTexture == null)
                return;

            float fullWidth = (float)layer.sourceTexture.width;
            float fullHeight = (float)layer.sourceTexture.height;

            Rect sourceRect = new Rect(
                Mathf.Ceil(camRect.x * fullWidth),
                Mathf.Ceil(camRect.y * fullHeight),
                Mathf.Ceil(camRect.width * fullWidth),
                Mathf.Ceil(camRect.height * fullHeight)
            );

            sourceRect.y = fullHeight - sourceRect.height - sourceRect.y; //Invert Y! fuck!
            layer.destTexture = TexturePool.GetTexture2D((int)sourceRect.width, (int)sourceRect.height, vBug.settings.recording.screenCapture.rtLinearColorSpace, layer.sourceTexture.format);
            layer.destTexture.ReadPixels(sourceRect, 0, 0, false);
        }

        #endregion
        //--------------------------------------- SCREENSHOT GRABBERS --------------------------------------
        //--------------------------------------- SCREENSHOT GRABBERS --------------------------------------













        //--------------------------------------- ASYNC OPERATIONS --------------------------------------
        //--------------------------------------- ASYNC OPERATIONS --------------------------------------
        #region ASYNC OPERATIONS


        private void HandleRequestState(IAbortableWorkObject requestDataObj)
        {
            ScreenCaptureRequest requestData = (ScreenCaptureRequest)requestDataObj;
            switch (requestData.state)
            {
                case ScreenCaptureRequest.State.getColors:
                    WorkloadDistributionManager.AddWork(WorkloadExecutorType.lateUpdate, Execute_getColors, requestData, HandleRequestState);
                    break;
                case ScreenCaptureRequest.State.getBytes:
                    WorkloadDistributionManager.AddWork(WorkloadExecutorType.thread, Execute_getBytes, requestData, HandleRequestState);
                    break;
                case ScreenCaptureRequest.State.complete:
                    WorkloadDistributionManager.AddWork(WorkloadExecutorType.fixedUpdate, Execute_complete, requestData, HandleRequestState);
                    break;
            }
        }




        private bool Execute_getColors(IAbortableWorkObject requestDataObj) {
            if (requestDataObj == null || requestDataObj.isAborted)
                return false;

            ScreenCaptureRequest requestData = (ScreenCaptureRequest)requestDataObj;
            requestData.state = ScreenCaptureRequest.State.getBytes; // Move to nextState before any crashes can occure
            if (requestData.renderLayers != null && requestData.renderLayers.Length > 0) {
                foreach (ScreenCaptureRequest.RenderLayer layer in requestData.renderLayers) {
                    if (layer.destTexture != null) {
                        layer.colorBuffer = layer.destTexture.GetPixels32();
                    } else {
                        if (vBug.settings.general.debugMode)
                            Debug.LogError("getColors ERROR! destTexture NULL! " + requestData.frameNumber);
                    }
                }
            } else {
                if (vBug.settings.general.debugMode)
                    Debug.LogError("getColors ERROR! renderLayers NULL! " + requestData.frameNumber);

                requestData.state = ScreenCaptureRequest.State.complete;
            }
            return true;
        }


        private bool Execute_getBytes(IAbortableWorkObject requestDataObj) {
            if (requestDataObj == null || requestDataObj.isAborted)
                return false;

            ScreenCaptureRequest requestData = (ScreenCaptureRequest)requestDataObj;
            requestData.state = ScreenCaptureRequest.State.complete; // Move to nextState before any crashes can occure

            foreach (ScreenCaptureRequest.RenderLayer layer in requestData.renderLayers) {
                if (layer.colorBuffer != null) {
                    layer.byteBuffer = TextureHelper.GetBytes(layer.colorBuffer, layer.destinationWidth, layer.destinationHeight, requestData.scaleDown, requestData.quality);
                } else {
                    if (vBug.settings.general.debugMode)
                        Debug.LogError("getBytes ERROR! colorBuffer NULL! " + requestData.frameNumber + ", isAborted? " + requestData.isAborted);
                }
            }
            return true;
        }


        private bool Execute_complete(IAbortableWorkObject requestDataObj)
        {
            if (requestDataObj == null || requestDataObj.isAborted)
                return false;

            ScreenCaptureRequest requestData = (ScreenCaptureRequest)requestDataObj;
            requestData.state = ScreenCaptureRequest.State.idle; // Move to nextState before any crashes can occure

            if (resultReadyCallback != null)
                resultReadyCallback(requestData.frameNumber, SetSnapshot(requestData), 0);

            requestData.Dispose();
            return true;
        }


        private ScreenCaptureSnapshot SetSnapshot(ScreenCaptureRequest requestData)
        {
            if (requestData == null || requestData.renderCams == null || requestData.renderLayers == null)
                return null;

            int iMax = requestData.renderCams.Length;
            string[] camNames = new string[iMax];
            byte[][] camRenders = new byte[iMax][];
            Rect[] camRects = new Rect[iMax];

            for(int i = 0; i < iMax; i++) {
                if (requestData.renderCams[i] == null)
                    continue;

                Camera cam = requestData.renderCams[i];
                camNames[i] = cam.name.Replace("vBug_", "");
                camRects[i] = cam.rect;
                camRenders[i] = requestData.renderLayers[i].byteBuffer;
            }
            return new ScreenCaptureSnapshot(camNames, camRenders, camRects, Camera.main, requestData.screenWidth, requestData.screenHeight);
        }

        #endregion
        //--------------------------------------- ASYNC OPERATIONS --------------------------------------
        //--------------------------------------- ASYNC OPERATIONS --------------------------------------

	
    }
}