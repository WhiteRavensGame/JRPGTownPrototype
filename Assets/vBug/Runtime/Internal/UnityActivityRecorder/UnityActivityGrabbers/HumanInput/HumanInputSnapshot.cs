//Copyright (c) 2015 by Michiel Frankfort, all rights reserved.      

using System;
using UnityEngine;


namespace Frankfort.VBug.Internal
{
    
    public enum HumanInputState
    {
        hold,
        move,
        down,
        downMove,
        downHold,
        up
    }


    
    public class InputCommand
    {
        public string id;
        public HumanInputState state;
        public SVector2 position;
        public float axis;

        public InputCommand() //Default constructor
        { }
        public InputCommand(string id, HumanInputState state)
        {
            this.id = id;
            this.state = state;
            this.position = SVector2.zero;
        }
        public InputCommand(string id, HumanInputState state, SVector2 position)
        {
            this.id = id;
            this.state = state;
            this.position = position;
        }
        public InputCommand(string id, float axis) {
            this.id = id;
            this.axis = axis;
        }

        public override string ToString()
        {
            return "id: " + id + ", state: " + state.ToString() + ", pos: " + position.ToString() + ", axis: " + axis;
        }

        public static void Serialize(InputCommand input, ref ComposedByteStream storeTo){
            float[] data = new float[4];
            data[0] = (int)input.state;
            data[1] = input.position.x;
            data[2] = input.position.y;
            data[3] = input.axis;
            
            storeTo.AddStream(input.id);
            storeTo.AddStream(data);
        }

        public static InputCommand Deserialize(ref ComposedByteStream stream)
        {
            InputCommand result = new InputCommand();
            result.id = stream.ReadNextStream();
            float[] data = stream.ReadNextStream<float>();

            result.state = (HumanInputState)data[0];
            result.position.x = data[1];
            result.position.y = data[2];
            result.axis = data[3];
            return result;
        }

        internal void Dispose() {
            id = null;
        }
    
    }



    
    public class HumanInputProviderData : BaseDisposable
    {

        //--------------- Serialize / Deserialize --------------------

        public static byte[] Serialize(HumanInputProviderData input) {
            if (input == null)
                return null;

            ComposedByteStream stream = ComposedByteStream.FetchStream();
            stream.AddStream(input.providerType);

            if (input.basicInput != null && input.basicInput.Length > 0) {
                ComposedByteStream subStream = ComposedByteStream.FetchStream();
                for (int i = 0; i < input.basicInput.Length; i++)
                    InputCommand.Serialize(input.basicInput[i], ref subStream);

                stream.AddStream(subStream.Compose());
            } else {
                stream.AddEmptyStream();
            }

            return stream.Compose();
        }


        public static HumanInputProviderData Deserialize(byte[] input) {
            if (input == null || input.Length == 0)
                return null;

            HumanInputProviderData result = new HumanInputProviderData();
            ComposedByteStream stream = ComposedByteStream.FromByteArray(input);
            result.providerType = stream.ReadNextStream();

            ComposedByteStream basic = ComposedByteStream.FromByteArray(stream.ReadNextStream<byte>());
            if (basic != null && basic.streamCount > 0) {
                int iMax = basic.streamCount / 2;
                result.basicInput = new InputCommand[iMax];
                for (int i = 0; i < iMax; i++)
                    result.basicInput[i] = InputCommand.Deserialize(ref basic);

                basic.Dispose();
            }

            stream.Dispose();
            return result;
        }
        //--------------- Serialize / Deserialize --------------------


        //--------------- Instance --------------------
        public string providerType;
        public InputCommand[] basicInput;
        

        public override void Dispose() {
            base.Dispose();

            if (basicInput != null) {
                foreach (InputCommand command in basicInput) {
                    if (command != null)
                        command.Dispose();
                }
            }
            providerType = null;
            basicInput = null;
        } 
        //--------------- Instance --------------------
    }



    
    public class HumanInputSnapshot : BaseDisposable
    {
        //--------------- Serialize / Deserialize --------------------
        public static byte[] Serialize(HumanInputSnapshot input) {
            if (input == null)
                return null;

            ComposedByteStream stream = ComposedByteStream.FetchStream();
            foreach (HumanInputProviderData data in input.providersData)
                stream.AddStream(HumanInputProviderData.Serialize(data));

            return stream.Compose();
        }

        public static HumanInputSnapshot Deserialize(byte[] input) {
            if (input == null || input.Length == 0)
                return null;

            HumanInputSnapshot result = new HumanInputSnapshot();
            ComposedByteStream stream = ComposedByteStream.FromByteArray(input);
            if (stream == null)
                return null;

            int iMax = stream.streamCount;
            result.providersData = new HumanInputProviderData[iMax];
            for (int i = 0; i < iMax; i++)
                result.providersData[i] = HumanInputProviderData.Deserialize(stream.ReadNextStream<byte>());

            stream.Dispose();
            return result;
        }
        //--------------- Serialize / Deserialize --------------------


        //--------------- Instance --------------------
        public HumanInputProviderData[] providersData;

        public HumanInputSnapshot() //Default constructor.
        { }

        public HumanInputSnapshot(HumanInputProviderData[] providersData) {
            this.providersData = providersData;
        }

        public override void Dispose() {
            base.Dispose();
            if (providersData != null) {
                foreach (HumanInputProviderData data in providersData) {
                    if (data != null)
                        data.Dispose();
                }
            }
            providersData = null;
        } 
        //--------------- Instance --------------------
			
    }
}