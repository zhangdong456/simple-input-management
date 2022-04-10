
using System;
using UnityEngine;

namespace CustomInput
{
    public class CompoundAxisInput: IAxisInput
    {
        public IAxisInput[] Axis;

        private int m_lastPressedIndex;
        
        public CompoundAxisInput(params IAxisInput[] axis)
        {
            Axis = axis;
        }

        public CompoundAxisInput()
        {
        }
        


        public float AxisValue()
        {
            float minValue = 0f;
            float maxValue = 0f;
            if (Axis!=null)
            {
                for (int i = 0; i < Axis.Length; i++)
                {
                    float num = Axis[i].AxisValue();
                    if (Mathf.Abs(num)>0.2f)
                    {
                        m_lastPressedIndex = i;
                    }

                    if (num<0f)
                    {
                        minValue = Mathf.Min(minValue, num);
                    }
                    else
                    {
                        maxValue = Mathf.Max(maxValue, num);
                    }
                }
            }

            return minValue + maxValue;
        }

        public void Add(IAxisInput axis)
        {
            if (Axis==null)
            {
                Axis = new IAxisInput[1];
                Axis[0] = axis;
                return;
            }
            Array.Resize<IAxisInput>(ref Axis,Axis.Length+1);
            Axis[Axis.Length - 1] = axis;
        }

        public void Clear()
        {
            Axis = null;
        }
    }

}

