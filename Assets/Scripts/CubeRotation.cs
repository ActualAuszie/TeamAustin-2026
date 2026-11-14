using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_MouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            m_MouseDown = true;
            if (Physics.Raycast(ray, out hit, 500.0f))
            {
                if (hit.collider.gameObject.name == "Cube")
                {
                    m_MouseDown = false;
                }
            }
        }


        if (Input.GetMouseButtonUp(0))
            m_MouseDown = false;
       
        Vector3 clickPos = ray.GetPoint(100);
        Vector3 axis = Vector3.Cross(Camera.main.transform.forward, transform.position - clickPos); 

        if (m_MouseDown)
           transform.Rotate(axis, 1.0f, Space.World);

        if (Input.GetMouseButtonDown(1))
            transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    bool m_MouseDown;
}
