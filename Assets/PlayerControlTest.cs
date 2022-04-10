using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInput;

public class PlayerControlTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LogicInput.Jump.OnPressed)
        {
            Debug.Log("Jump");
        }

        if (LogicInput.Cancel.Pressed)
        {
            Debug.Log("Cancel");
        }
        
    }
}
