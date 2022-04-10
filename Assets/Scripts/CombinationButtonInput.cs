using System;
using System.Collections;
using System.Collections.Generic;
using CustomInput;
using UnityEngine;

namespace CustomInput
{
    //组合按钮 指的是比如ctrl+1 或者其他他 R+T这种组合才会生效的按钮
    public class CombinationButtonInput : IButtonInput
    {
        public IButtonInput[] Buttons;
        private bool isCheckClick = false;
        private float clickTime = 0;
        private int m_lastPressedIndex;
        public CombinationButtonInput(params IButtonInput[] buttons)
        {
            Buttons = buttons;
        }
        public bool GetButton()
        {
            if (Buttons!=null)
            {
                if (isCheckClick)
                {
                    if ((clickTime+=Time.deltaTime)>0.2f)
                    {
                        isCheckClick = false;
                        clickTime = 0f;
                    }
                }

                bool isButton = false;
                for (int i=0;i<Buttons.Length;++i)
                {
                    if (Buttons[i].GetButton())
                    {
                      
                        clickTime = 0f;
                        if (isCheckClick
                            && m_lastPressedIndex!=i )
                        {
                            isCheckClick = false;
                            isButton = true;
                        }
                        else
                        {
                            m_lastPressedIndex = i;
                            isCheckClick = true;
                            
                        }
                    }
                }

                return isButton;
            }

            return false;
        }
        //该组合仅仅支持两种按钮组合方式
        public void Add(IButtonInput button1,IButtonInput button2)
        {
            Buttons = new IButtonInput[2];
            Buttons[0] = button1;
            Buttons[1] = button2;
        }

        public void Clear()
        {
            Buttons = null;
        }
    }
}
