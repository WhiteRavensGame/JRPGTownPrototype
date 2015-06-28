//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using UnityEditor;
using UnityEngine;
using Frankfort.VBug.Internal;
using System.Collections.Generic;


namespace Frankfort.VBug.Editor {

    public class PlaybackXBoxControllerOverlay: BasePlaybackOverlay {

        public PlaybackXBoxControllerOverlay() {
            this.doDrawMainContainer = false;
            this.doDrawSubContainer = true;
        }

        public override bool DrawSubContainer(int currentFrame, vBugBaseWindow parent) {
            VerticalActivitySlice slice = VerticalSliceDatabase.GetSlice(currentFrame);

            bool succes = false;
            if (slice != null && slice.humanInput != null && slice.humanInput.providersData != null) {
                foreach (HumanInputProviderData provider in slice.humanInput.providersData) {
                    if (provider == null)
                        continue;

                    if (provider.providerType == "XBoxControllerInputProvider" && provider.basicInput != null) {
                        DrawVirtualController(provider, parent);
                        succes = true;
                        break;
                    }
                }
            }
            if (!succes)
                EditorHelper.DrawNA(new Rect(0, 0, parent.position.width, parent.position.height), "XBox controller data not available");

            return true;
        }


        private void DrawVirtualController(HumanInputProviderData data, vBugBaseWindow parent) {
            //Rect xboxRect = VisualResources.DrawXBoxControllerBG();

        }
    }
}