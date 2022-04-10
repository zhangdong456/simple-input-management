
using System;

namespace CustomInput
{
    //复合按钮输入类
    public class CompoundButtonInput : IButtonInput
    {
        public IButtonInput[] Buttons;
        private int m_lastPressedIndex;
        public CompoundButtonInput(params IButtonInput[] buttons)
        {
            Buttons = buttons;
        }

        public CompoundButtonInput()
        {
        }
        public bool GetButton()
        {
            if (Buttons!=null)
            {
                for (int i = 0; i < Buttons.Length; i++)
                {
                    if (Buttons[i].GetButton())
                    {
                        m_lastPressedIndex = i;
                        return true;
                    }
                }
            }

            return false;
        }

        public IButtonInput GetLastPressed()
        {
            return Buttons[m_lastPressedIndex];
        }

        public void Add(IButtonInput button)
        {
            if (Buttons==null)
            {
                Buttons = new IButtonInput[]{button};
                return;
            }
            Array.Resize<IButtonInput>(ref Buttons, Buttons.Length + 1);
            Buttons[Buttons.Length - 1] = button;
        }

        public void Clear()
        {
            Buttons = null;
        }
    }
}


