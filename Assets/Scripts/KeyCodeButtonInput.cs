
using UnityEngine;

namespace CustomInput
{
    public class KeyCodeButtonInput :IButtonInput
    {
        private readonly KeyCode m_keyCode;
        public KeyCode KeyCode
        {
            get { return m_keyCode; }
        }
        public KeyCodeButtonInput(KeyCode keyCode)
        {
            m_keyCode = keyCode;
        }
        public bool GetButton()
        {
            return Input.GetKey(m_keyCode);
        }
    }

}

