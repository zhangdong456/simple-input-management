using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInput;
public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;

    //按键复合输入
    public CompoundButtonInput Jump = new CompoundButtonInput();
    public CompoundButtonInput Cancel = new CompoundButtonInput();
    public CompoundButtonInput Attack = new CompoundButtonInput();

    //轴值复合输入
    public CompoundAxisInput HorizontalDlgiPad = new CompoundAxisInput();
    public CompoundAxisInput VerticalDlgiPad = new CompoundAxisInput();

    public IButtonInput LeftClick;
    public IButtonInput RightClick;
    
    public List<IButtonInput> m_allButtonInputs = new List<IButtonInput>();
    public List<IAxisInput> m_allAxisInputs = new List<IAxisInput>();
    public List<InputButtonProcessor> m_allButtonProcessors = new List<InputButtonProcessor>();
    private int m_lastPressedButtonInput = -1;
    private int m_lastPressedAxisInput = -1;
    public void AddKeyboardControls()
    {
        HorizontalDlgiPad.Add(new ButtonAxisInput(new KeyCodeButtonInput(KeyCode.A),ButtonAxisInput.Mode.Negative));
        HorizontalDlgiPad.Add(new ButtonAxisInput(new KeyCodeButtonInput(KeyCode.D), ButtonAxisInput.Mode.Positive));
        HorizontalDlgiPad.Add(new ButtonAxisInput(new KeyCodeButtonInput(KeyCode.LeftArrow), ButtonAxisInput.Mode.Negative));
        HorizontalDlgiPad.Add(new ButtonAxisInput(new KeyCodeButtonInput(KeyCode.RightArrow), ButtonAxisInput.Mode.Positive));
        
        VerticalDlgiPad.Add(new ButtonAxisInput(new KeyCodeButtonInput(KeyCode.S), ButtonAxisInput.Mode.Negative));
        VerticalDlgiPad.Add(new ButtonAxisInput(new KeyCodeButtonInput(KeyCode.W), ButtonAxisInput.Mode.Positive));
        VerticalDlgiPad.Add(new ButtonAxisInput(new KeyCodeButtonInput(KeyCode.DownArrow), ButtonAxisInput.Mode.Negative));
        VerticalDlgiPad.Add(new ButtonAxisInput(new KeyCodeButtonInput(KeyCode.UpArrow), ButtonAxisInput.Mode.Positive));
        
        Jump.Add(new KeyCodeButtonInput(KeyCode.Space));
        Jump.Add(new KeyCodeButtonInput(KeyCode.Z));
        
        Cancel.Add(new KeyCodeButtonInput(KeyCode.Escape));
        Cancel.Add(new KeyCodeButtonInput(KeyCode.Mouse1));
        
        Attack.Add(new KeyCodeButtonInput(KeyCode.R));
        Attack.Add(new KeyCodeButtonInput(KeyCode.T));
        
        
        LeftClick = new KeyCodeButtonInput(KeyCode.Mouse0);
        RightClick = new KeyCodeButtonInput(KeyCode.Mouse1);
    }

    private void Awake()
    {
        Instance = this;
        RefreshControlScheme();
        m_allButtonInputs = new List<IButtonInput>
        {
            Jump,
            Attack,
            Cancel,
        };
        m_allButtonProcessors = new List<InputButtonProcessor>
        {
           LogicInput.Jump,
           LogicInput.Attack,
           LogicInput.Cancel,
        };
        m_allAxisInputs = new List<IAxisInput>
        {
            HorizontalDlgiPad,
            VerticalDlgiPad
        };
    }
    public void Update()
    {
        RefreshControls();
    }
    public void ClearControls()
    {
        HorizontalDlgiPad.Clear();
        VerticalDlgiPad.Clear();
        Jump.Clear();
        Attack.Clear();
        Cancel.Clear();
    }
    public void RefreshControlScheme()
    {
        ClearControls();
        AddKeyboardControls();
    }

    public void RefreshControls()
    {
        //复合轴更新
        LogicInput.HorizontalDigiPadValue = Mathf.RoundToInt(HorizontalDlgiPad.AxisValue());
        LogicInput.VerticalDigiPadValue = Mathf.RoundToInt(VerticalDlgiPad.AxisValue());
        LogicInput.HorizontalValue = Mathf.Clamp((float)LogicInput.HorizontalDigiPadValue, -1f, 1f);
        LogicInput.VerticalValue = Mathf.Clamp((float)LogicInput.VerticalDigiPadValue, -1f, 1f);
        LogicInput.LeftStick.Update(LeftClick.GetButton());
        LogicInput.RightStick.Update(RightClick.GetButton());
        LogicInput.Down.Update(LogicInput.NormalizedVertical == -1f);
        LogicInput.Up.Update(LogicInput.NormalizedVertical == 1f);
        LogicInput.Left.Update(LogicInput.NormalizedHorizontal == -1);
        LogicInput.Right.Update(LogicInput.NormalizedHorizontal == 1);
        //复合按钮更新
        m_lastPressedButtonInput = -1;
        for (int i = 0; i < m_allButtonInputs.Count; i++)
        {
            bool b_Clicked = m_allButtonInputs[i].GetButton();
            if (b_Clicked)
            {
                m_lastPressedButtonInput = i;
            }
            m_allButtonProcessors[i].Update(b_Clicked);
        }
    }
}
