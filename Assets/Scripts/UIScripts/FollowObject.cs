using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowObject : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject canvas;
    //float distance = 3f;

    // Update is called once per frame
    void Update()
    {

        // Vector3 cameraToObj =  UIPanel.transform.position - mainCam.transform.position;
        // float angle = Vector3.Angle(cameraToObj, mainCam.transform.forward);
        // float x = Mathf.Cos(angle * Mathf.Deg2Rad) * distance;
        // float z = Mathf.Sin(angle * Mathf.Deg2Rad) * distance;

        canvas.transform.position = mainCam.transform.position + 3*mainCam.transform.forward;
        canvas.transform.rotation = mainCam.transform.rotation;

        
        
    }
}


