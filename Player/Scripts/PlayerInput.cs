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


    [HideInInspector] public float Horizontal, Vertical;
    [HideInInspector] public float MouseX, MouseY;
    public Action OnJump;

    private void Update()
    {
        if (!VisibleCursor)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
            
        Cursor.visible = VisibleCursor;

        if (Controls == Controller.PC)
        {
            MouseX = Input.GetAxis("Mouse X") * 10;
            MouseY = Input.GetAxis("Mouse Y") * 10;

            InputPC();

            MobileCanvas.SetActive(false);
            return;
        }

        if (Controls == Controller.Mobile)
        {
            MouseX = TouchField.TouchAxis.x;
            MouseY = TouchField.TouchAxis.y;

            InputMobile();

            MobileCanvas.SetActive(true);
            return;
        }
    }

    private void InputPC()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            OnJump?.Invoke();
    }

    private void InputMobile()
    {
        Horizontal = FloatingJoystick.Horizontal;
        Vertical = FloatingJoystick.Vertical;
    }
}
