
using UnityEditor;

namespace CustomInput
{
    public class InputButtonProcessor
    {
        public bool WasPressed;
        public bool IsPressed;
        public bool Used;

        public bool OnPressed
        {
            get
            {
                return this.IsPressed && !this.WasPressed;
            }
        }

        public bool OnPressedNotUsed
        {
            get
            {
                return this.IsPressed && !this.WasPressed && !this.Used;
            }
        }

        public bool OnReleased
        {
            get
            {
                return !this.IsPressed && this.WasPressed;
            }
        }

        public bool Pressed
        {
            get
            {
                return this.IsPressed;
            }
        }

        public bool Released
        {
            get
            {
                return !this.IsPressed;
            }
        }

        public void Update(bool isPressed)
        {
            this.WasPressed = this.IsPressed;
            this.IsPressed = isPressed;
        }
    }
}