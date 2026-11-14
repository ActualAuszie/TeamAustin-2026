using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private CameraBehaviour cameraBehavior;

    void Awake()
    {
        if (cameraBehavior == null)
            cameraBehavior = this.GetComponent<CameraBehaviour>();
    }

    void Update ()
    {
		
	}

    void LateUpdate()
    {
        if(m_Player == null)
        {
            return;
        }

        if(m_CurrentBehaviour != null)
        {
            m_CurrentBehaviour.UpdateCamera();

            ControlRotation = m_CurrentBehaviour.GetControlRotation();
        }
    }

    public void SetPlayer(NetworkPlayer player)
    {
        m_Player = player;

        if(m_Player != null)
        {
            LookPos = m_Player.transform.position;
        }

        cameraBehavior.Init(this, m_Player);

        SetCameraBehaviour(cameraBehavior);
    }

    public void UpdateRotation(float yawAmount, float pitchAmount)
    {
        if(m_CurrentBehaviour != null)
        {
            m_CurrentBehaviour.UpdateRotation(yawAmount, pitchAmount);
        }
    }

    public void SetFacingDirection(Vector3 direction)
    {
        if (m_CurrentBehaviour != null)
        {
            m_CurrentBehaviour.SetFacingDirection(direction);
        }
    }

    public Vector3 ControlRotation { get; private set; }
    public Vector3 LookPos { get; set; }

    public Vector3 PivotRotation { get; set; }

    void SetCameraBehaviour(CameraBehaviour behaviour)
    {
        if (m_CurrentBehaviour == behaviour)
        {
            return;
        }

        if (m_CurrentBehaviour != null)
        {
            m_CurrentBehaviour.Deactivate();
        }

        m_CurrentBehaviour = behaviour;

        if (m_CurrentBehaviour != null)
        {
            m_CurrentBehaviour.Activate();
        }
    }

    CameraBehaviour m_CurrentBehaviour;
    NetworkPlayer m_Player;
}
