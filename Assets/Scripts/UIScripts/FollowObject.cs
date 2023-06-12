using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowObject : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject UIpanel;
    public GameObject manualPanel;

    //float distance = 10f;

    // Update is called once per frame
    void Update()
    {


        UIpanel.transform.position = mainCam.transform.position + 3*mainCam.transform.forward;
        UIpanel.transform.rotation = mainCam.transform.rotation;

        manualPanel.transform.position = mainCam.transform.position + 6* mainCam.transform.forward;
        manualPanel.transform.rotation = mainCam.transform.rotation;



    }
}


