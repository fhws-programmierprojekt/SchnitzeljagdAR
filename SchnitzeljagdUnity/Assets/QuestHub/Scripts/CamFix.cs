using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFix : MonoBehaviour
{
    public Camera m_Camera;

    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
        m_Camera.transform.rotation * Vector3.up);
    }

}
