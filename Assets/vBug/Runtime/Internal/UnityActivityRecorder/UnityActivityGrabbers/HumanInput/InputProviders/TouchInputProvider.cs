﻿//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Frankfort.VBug.Internal {
    public class TouchInputProvider : IHumanInputProvider {
        private HumanInputProviderData currentResult;

        //--------------- IHumanInputProvider --------------------
        public void Init() {
        }
        public void Reset() {
        }

        public void InitCurrentFrame() {
            if (Application.platform == RuntimePlatform.WindowsEditor ||
                Application.platform == RuntimePlatform.WindowsPlayer ||
                Application.platform == RuntimePlatform.WindowsWebPlayer ||
                Application.platform == RuntimePlatform.OSXDashboardPlayer ||
                Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer ||
                Application.platform == RuntimePlatform.OSXWebPlayer)
                return;
            currentResult = new HumanInputProviderData();
            currentResult.providerType = this.GetType().Name;
            currentResult.basicInput = GetTouchCommands();
        }

        public HumanInputProviderData GetResultEOF() {
            return currentResult;
        }

        public void Dispose() 
        { }
        //--------------- IHumanInputProvider --------------------




        private InputCommand[] GetTouchCommands() {

            List<InputCommand> result = new List<InputCommand>();

            int i = Input.touchCount;
            while (--i > -1) {

                Touch touch = Input.touches[i];
                Vector2 pos = touch.position;
                pos.y = Screen.height - pos.y;

                string id = touch.fingerId.ToString();
                switch (touch.phase) {
                    case TouchPhase.Began:
                        result.Add(new InputCommand(id, HumanInputState.down, pos));
                        break;

                    case TouchPhase.Stationary:
                        
                        result.Add(new InputCommand(id, HumanInputState.downHold, pos));
                        break;

                    case TouchPhase.Moved:
                        result.Add(new InputCommand(id, HumanInputState.downMove, pos));
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        result.Add(new InputCommand(id, HumanInputState.up, pos));
                        break;
                }
            }
            return result.ToArray();
        }
    }
}
