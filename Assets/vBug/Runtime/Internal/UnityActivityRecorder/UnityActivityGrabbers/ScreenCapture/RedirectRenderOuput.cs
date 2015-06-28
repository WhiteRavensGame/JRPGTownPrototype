using UnityEngine;
using System;
using System.Collections;

namespace Frankfort.VBug.Internal
{
    [ContextMenu("")]
    public class RedirectRenderOuput : MonoBehaviour {
        private static RedirectRenderOuput _instance;
        
        public static RedirectRenderOuput Instance {
            get {
                if (_instance == null) {
                    GameObject go = new GameObject("vBugRedirectRenderOutput");
                    go.transform.position = new Vector3(100000, 0, 0);///far far far away

                    //--------------- Cheap camera --------------------
                    Camera cam = go.AddComponent<Camera>();
                    cam.enabled = false;
                    cam.renderingPath = RenderingPath.VertexLit;
                    cam.clearFlags = CameraClearFlags.Nothing;
                    cam.cullingMask = 0; //nothing
                    cam.depthTextureMode = DepthTextureMode.None;

                    cam.orthographic = true;
                    cam.nearClipPlane = 0.01f;
                    cam.farClipPlane = 0.01f;
                    cam.orthographicSize = 0.01f;

                    cam.transparencySortMode = TransparencySortMode.Orthographic;
                    cam.useOcclusionCulling = false;
                    //--------------- Cheap camera --------------------

                    _instance = go.AddComponent<RedirectRenderOuput>();
                    _instance.cam = cam;
                }
                return _instance;
            }
        }



        private Camera cam;
        private RenderTexture rt;
        private bool isDestroyed;

        private void OnDestroy() {
            rt = null;
            cam = null;
            isDestroyed = true;
        }

        
        public void RedirectEOF(RenderTexture rt) {
            if (rt == null)
                return;

            this.rt = rt;
            this.cam.RenderDontRestore();
        }

        private void OnPostRender() {
            if(rt == null)
                return;

            Graphics.Blit(rt, null as RenderTexture);
            rt = null;
        }
    }
}