using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace Frankfort.VBug.Internal{
    public class XBoxControllerInputProvider : IHumanInputProvider{
        private HumanInputProviderData currentResult;
        private List<InputCommand> caughtCommands = new List<InputCommand>();

        private Dictionary<string, float> axisMoveDetectTable = new Dictionary<string, float>();

        //--------------- IHumanInputProvider --------------------
        public void Init() {
        }
        public void Reset() {
            caughtCommands.Clear();
            currentResult = new HumanInputProviderData();
        }

        public void InitCurrentFrame() {
            if (Application.platform == RuntimePlatform.Android ||
                Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.BlackBerryPlayer ||
                Application.platform == RuntimePlatform.WP8Player)
                return;

            currentResult = new HumanInputProviderData();
            currentResult.providerType = this.GetType().Name;
            currentResult.basicInput = GetKeyInput();
        }

        public HumanInputProviderData GetResultEOF() {
            return currentResult;
        }

        public void Dispose() {
            currentResult = new HumanInputProviderData();
        }
        //--------------- IHumanInputProvider --------------------




        private InputCommand[] GetKeyInput() {

            HumanInputSettings.XBoxControllerSettings settings = vBug.settings.recording.humanInputRecording.xbox;
            if (settings == null || settings.inputMapping == null)
                return null;

            Type type = typeof(KeyCode);
            for(int i = 0;i < settings.inputMapping.Length; i ++){
                
                string key = settings.inputMapping[i].key.ToString();
                if(settings.inputMapping[i].isAxis){
                    
                    caughtCommands.Add(new InputCommand(key, Input.GetAxis(settings.inputMapping[i].value)));

                } else {
                    KeyCode code = (KeyCode)Enum.Parse(type, settings.inputMapping[i].value);
                    if(Input.GetKeyDown(code)){
                        caughtCommands.Add(new InputCommand(key, HumanInputState.down));
                    } else if(Input.GetKey(code)){
                        caughtCommands.Add(new InputCommand(key, HumanInputState.downHold));
                    } else if(Input.GetKeyUp(code)){
                        caughtCommands.Add(new InputCommand(key, HumanInputState.up));
                    }
                    
                }
            }

            return caughtCommands.ToArray();
        }

    }
}
