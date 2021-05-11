using System;
using UnityEngine;


namespace until.system.singleton
{
    [DisallowMultipleComponent]
    public class InputManager : Singleton<InputManager>
    {
        #region Properties.
        #endregion

        #region Fields.
        private InputButton CurrentDown = InputButton.None;
        private InputButton CurrentTrig = InputButton.None;
        private InputButton CurrentRelease = InputButton.None;
        private InputStick CurrentLStick = new InputStick();
        private InputStick CurrentRStick = new InputStick();
        private InputDevice CurrentDevice = null;
        #endregion

        #region Methods.
        public override void onSingletonAwake()
        {
        }

        public override void onSingletonStart()
        {
            CurrentDevice = new InputDeviceDualshock4();
        }

        public override void onSingletonDestroy()
        {
        }

        // Update is called once per frame
        public void onUpdate()
        {
            if(CurrentDevice != null)
            {
                var NextDown = CurrentDevice.getButton();
                CurrentTrig = ~CurrentDown & NextDown;
                CurrentRelease = CurrentDown & ~NextDown;
                CurrentDown = NextDown;
                CurrentLStick = CurrentDevice.getLStick();
                CurrentRStick = CurrentDevice.getRStick();
            }
        }
        #endregion

        #region Check Functions
        public bool isDown(InputPad pad, InputButton button)
        {
            return (CurrentDown & button) != InputButton.None;
        }

        public bool isTrig(InputPad pad, InputButton button)
        {
            return (CurrentTrig & button) != InputButton.None;
        }

        public bool isRelease(InputPad pad, InputButton button)
        {
            return (CurrentRelease & button) != InputButton.None;
        }

        public InputStick getStick(InputPad pad, InputStickType InStickType)
        {
            switch(InStickType)
            {
                case InputStickType.L:
                    return CurrentLStick;
                case InputStickType.R:
                    return CurrentRStick;
                default:
                    return null;
            }
        }
        #endregion
    }
}
