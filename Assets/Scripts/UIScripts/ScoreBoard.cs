using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    public GameObject scoreCube;
    public GameObject scoreCanvas;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowScoreCube();
    }

    private void FollowScoreCube()
    {
        //scoreCanvas.transform.position = scoreCube.transform.position + 3 * scoreCube.transform.forward;
        //scoreCanvas.transform.rotation = scoreCube.transform.rotation;

    }
}
