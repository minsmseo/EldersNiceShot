using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject hammer;
    public RectTransform uiPanel;


    // Update is called once per frame
    void Update()
    {

        uiPanel.position = Camera.main.WorldToScreenPoint(hammer.transform.position);
    }
}
