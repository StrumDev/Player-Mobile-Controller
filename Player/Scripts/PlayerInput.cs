using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    public enum Controller { PC, Mobile }

    public Controller Controls;

    [Header("Camera")]
    public float Sensitivity = 0.3f;
    public bool VisibleCursor = true;

    [Header("Mobile")]
    public GameObject MobileCanvas;
    public TouchField TouchField;
    public FloatingJoystick FloatingJoystick;


    public float Horizontal => Controls == Controller.PC ? Input.GetAxis("Horizontal") : FloatingJoystick.Horizontal;
    public float Vertical => Controls == Controller.PC ? Input.GetAxis("Vertical") : FloatingJoystick.Vertical;

    public float MouseX => Controls == Controller.PC ? Input.GetAxis("Mouse X") * 10 : TouchField.TouchAxis.x;
    public float MouseY => Controls == Controller.PC ? Input.GetAxis("Mouse Y") * 10 : TouchField.TouchAxis.y;

    public Action OnJump;
    public Action<bool> OnRun;

    private void Update()
    {
        if (Cursor.visible != VisibleCursor)
        {
            if (!VisibleCursor)
                Cursor.lockState = CursorLockMode.Locked;
            else 
                Cursor.lockState = CursorLockMode.None;
                
            Cursor.visible = VisibleCursor;
        }

        if (Controls == Controller.PC)
        {
            OnRun?.Invoke(Input.GetKey(KeyCode.LeftShift));

            if (Input.GetKeyDown(KeyCode.Space))
                OnJump?.Invoke();
            
            MobileCanvas.SetActive(false);
            return;
        }

        if (Controls == Controller.Mobile)
        {
            MobileCanvas.SetActive(true);
            return;
        }
    }

    public void RunEvent(bool isRun)
    {
        OnRun?.Invoke(isRun);
    }

    public void JumpEvent()
    {
        OnJump?.Invoke();
    }
}