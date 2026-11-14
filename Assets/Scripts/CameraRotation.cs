using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject RefObj;
    void Start()
    {
        m_PivotRotation = Vector3.zero;
		m_DistFromPlayer = 200.0f;
        m_MouseDown = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500.0f))
            {
                if(hit.collider.gameObject.name == "Cube")
                {
                    m_MouseDown = true;
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            m_MouseDown = false;
        }

        if (m_MouseDown)
        {
            Vector3 worldPivotPos = RefObj.transform.TransformPoint(Vector3.zero);
            float pitchInput = -Input.GetAxis("Mouse Y"); //Input.GetAxis("Vertical");
            float yawInput = Input.GetAxis("Mouse X"); //Input.GetAxis("Horizontal");
            Vector3 rotateAmount = new Vector3(pitchInput * 5, yawInput * 5);

            m_PivotRotation.y += rotateAmount.y;

            m_PivotRotation.x -= rotateAmount.x;
            m_PivotRotation.x = Mathf.Clamp(m_PivotRotation.x, -89.9f, 89.9f);


            if (Input.GetKey(KeyCode.Z))
                m_DistFromPlayer -= 2.5f;

            if (Input.GetKey(KeyCode.X))
                m_DistFromPlayer += 2.5f;

            Vector3 offsetFromPlayer = Vector3.zero;

            offsetFromPlayer = Quaternion.Euler(m_PivotRotation.x, m_PivotRotation.y, 0.0f) * Vector3.forward;
            offsetFromPlayer *= m_DistFromPlayer;
            // Debug.Log(offsetFromPlayer);
            m_GoalPos = offsetFromPlayer + worldPivotPos;

            Vector3 newCameraPos = transform.position;

            newCameraPos = m_GoalPos;

            transform.position = newCameraPos;

            Vector3 goalLookPos = RefObj.transform.TransformPoint(Vector3.zero);

            Vector3 lookDir = goalLookPos - transform.position;

            transform.rotation = Quaternion.LookRotation(lookDir);
        }

    }

	float m_DistFromPlayer;
	Vector3 m_PivotRotation;
    Vector3 m_GoalPos;
    bool m_MouseDown;
}
