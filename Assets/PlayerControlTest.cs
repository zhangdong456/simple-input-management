using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInput;

public class PlayerControlTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Jump这个事件 当space或者Z键按下时都会触发 
        if (LogicInput.Jump.DownPressed)
        {
            Debug.Log("Jump");
        }

        if (LogicInput.Cancel.Pressed)
        {
            Debug.Log("Cancel");
        }
        //方向left事件 支持A或者左方向键
        if (LogicInput.Left.DownPressed)
        {
            Debug.Log("leftleftleft");
        }
        //组合按键触发 切换技能点击事件
        if (LogicInput.ChangeSkill.DownPressed)
        {
            Debug.Log("切换技能");
        }
    }
}
