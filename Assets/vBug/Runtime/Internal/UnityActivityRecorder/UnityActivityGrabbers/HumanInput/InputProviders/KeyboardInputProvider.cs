//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using System.Collections.Generic;
using UnityEngine;


namespace Frankfort.VBug.Internal
{
    public class KeyboardInputProvider : IHumanInputProvider
    {

        //--------------- IHumanInputProvider --------------------
        HumanInputProviderData currentResult;
        public void Init()
        {
        }
        public void Reset()
        {
        }

        public void InitCurrentFrame(){
            if (Application.platform == RuntimePlatform.Android || 
                Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.BlackBerryPlayer || 
                Application.platform == RuntimePlatform.WP8Player)
                return;

            currentResult = new HumanInputProviderData();
            currentResult.providerType = this.GetType().Name;
            currentResult.basicInput = GetKeyboardCommands();
        }

        public void Dispose()
        {
            currentResult = new HumanInputProviderData();
        }

        public HumanInputProviderData GetResultEOF()
        {
            return currentResult;
        } 
        //--------------- IHumanInputProvider --------------------




        private InputCommand[] GetKeyboardCommands()
        {
            if (!Input.anyKey && !Input.anyKeyDown)
                return null;

            KeyCode[] values = (KeyCode[])Enum.GetValues(typeof(KeyCode));
            List<InputCommand> result = new List<InputCommand>();

            int i = values.Length;
            while(--i > -1)
            {
                KeyCode key = values[i];
                if(Input.GetKeyDown(key))
                {
                    result.Add(new InputCommand(key.ToString(), HumanInputState.down));
                }
                else if (Input.GetKey(key))
                {
                    result.Add(new InputCommand(key.ToString(), HumanInputState.hold));
                }
                else if (Input.GetKeyUp(key))
                {
                    result.Add(new InputCommand(key.ToString(), HumanInputState.up));
                }
            }

            return result.ToArray();
        }
    }
}