using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleFirstPersonCamers : CameraBehaviour
{
    public float Sensitivity = 1500.0f;

    GameObject Cube;
    public SimpleFirstPersonCamers()
    {
        m_XRotation = 0.0f;
        m_YRotation = 0.0f;

    }

    public override void Activate()
    {
        base.Activate();

        //Cube = GameObject.Find("Cube");

        Debug.Log("Behaviour Activated");

        foreach(MeshRenderer mr in m_Player.transform.GetComponentsInChildren<MeshRenderer>())
        {
            if(mr)
            {
                mr.enabled = false;
            }
        }
       

    }

    public override void Deactivate()
    {
        base.Deactivate();
        Debug.Log("Behaviour Deactivated");
    }

    public override void UpdateRotation(float yawAmount, float pitchAmount)
    {
        Debug.Log("Update Rotationd");
    }

    public override void SetFacingDirection(Vector3 direction)
    {
        Debug.Log("Set Facing Direction");
    }

    public override Vector3 GetControlRotation()
    {
        return base.GetControlRotation();
    }

    public override bool UsesStandardControlRotation()
    {
        return false;
    }

    public override void UpdateCamera()
    {
        Vector3 playerPos = m_Player.transform.position;
        playerPos.y += 2;
        m_Camera.transform.position = playerPos;
     
        Vector3 lookInput = m_Player.Controller.GetLookInput();
        float mouseX = lookInput.y * Time.deltaTime * Sensitivity;
        float mouseY = lookInput.x * Time.deltaTime * Sensitivity;

        m_YRotation += mouseX;
        //m_YRotation = MathUtils.LerpTo(5.0f,m_YRotation, m_YRotation + mouseX, Time.deltaTime);


        m_XRotation -= mouseY;
        //m_XRotation = MathUtils.LerpTo(5.0f, m_XRotation, m_XRotation - mouseY, Time.deltaTime);

        m_XRotation = Mathf.Clamp(m_XRotation, -90f, 90f);

        m_Player.transform.rotation = Quaternion.Euler(0, m_YRotation, 0);
        m_Camera.transform.rotation = Quaternion.Euler(new Vector3(m_XRotation, m_YRotation, 0));

       // Vector3 camForward = Vector3.Cross(m_Camera.transform.up, m_Camera.transform.right);
       // Cube.transform.position = playerPos - camForward * 10.0f;


    }

    float m_XRotation;

    float m_YRotation;

}
