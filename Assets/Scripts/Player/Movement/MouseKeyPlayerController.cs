using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MouseKeyPlayerController : PlayerController
{
    public ThirdPersonCamera ControlCamera { get; private set; }
    public void Init(NetworkPlayer player)
    {
        if (ControlCamera = Camera.main.GetComponent<ThirdPersonCamera>())
        {
            ControlCamera.SetPlayer(player);
        }
    }

    public MouseKeyPlayerController()
    {

    }

    public void UpdateControls()
    {
        if (ControlCamera == null)
        {
            return;
        }
        UpdateMouseControlToggle();
        Vector3 lookInput = GetLookInput();
        ControlCamera.UpdateRotation(lookInput.y, lookInput.x);
    }

    public void SetFacingDirection(Vector3 direction)
    {
        ControlCamera.SetFacingDirection(direction);
    }

    public void AddLedgeDir(Vector3 ledgeDir)
    {

    }

    public Vector3 GetControlRotation()
    {
        return ControlCamera.ControlRotation;
    }

    public Vector3 GetMoveInput()
    {
        return new Vector3(
            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical")
            );
    }

    public Vector3 GetLookInput()
    {
        //Don't allow looking around if mouse isn't enabled
        if (!m_EnableMouseControl)
        {
            return Vector3.zero;
        }

        return new Vector3(
            Input.GetAxis("Mouse Y"),
            Input.GetAxis("Mouse X"),
            0.0f
            );
    }

    public bool IsJumping()
    {
        return Input.GetButton("Jump");
    }

    public bool IsFiring()
    {
        if (!m_EnableMouseControl)
        {
            return false;
        }

        return Input.GetButton("Fire1");
    }

    void UpdateMouseControlToggle()
    {
        //Check for a mouse click to lock and enable mouse control
        //GUIUtility.hotControl will be non-zero if a UI element was clicked.  If this is the case ignore the input.
        //if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        //Set enable mouse control here.  This can change outside of our control so we'll check it every frame.
        m_EnableMouseControl = Cursor.lockState == CursorLockMode.Locked;

        Cursor.visible = !m_EnableMouseControl;
    }

    bool m_EnableMouseControl;

}
