using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    private bool isPressed = false;
    
    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                isPressed = true;
            }
            else
            {
                if (isPressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.Click);
                    isPressed = false;
                }
            }
        }
    }
}
