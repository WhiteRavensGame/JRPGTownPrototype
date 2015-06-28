//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using UnityEngine;
using System.Collections;


namespace Frankfort.VBug.Editor
{
    [AddComponentMenu(""), ExecuteInEditMode]
    public class WindowRenderer : MonoBehaviour //Rename because of 'Its not a monobehaviour' error @Unity-Free
    {

        private GameObject[] gameObjects;
        private bool visible = false;
    
        
        public void SetObjectsToRender(Rect pixelRect, GameObject[] gameObjects)
        {
            this.gameObjects = gameObjects;
            SetGameObjectsActive(true);
        }

        private void OnPostRender(){
            Hide();
        }

        private void Update(){
            Hide();
        }

        public void Hide(){
            SetGameObjectsActive(false);
            gameObjects = null;
        }

        

        private void SetGameObjectsActive(bool state)
        {
            if (visible == state)
                return;
            visible = state;

            if (gameObjects == null || gameObjects.Length == 0)
                return;

            foreach (GameObject go in gameObjects)
            {
                Renderer[] renderers = go.GetComponentsInChildren<Renderer>(true);
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].enabled = state;
                    if (state && renderers[i].sharedMaterial != null)
                    {
                        renderers[i].sharedMaterial.renderQueue = 3000 + i;
                        renderers[i].sharedMaterial.SetFloat("_Offset", -i);
                    }
                }
            }

        }
    }
}
