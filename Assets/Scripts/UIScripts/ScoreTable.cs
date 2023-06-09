using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{

    public GameObject Cube;
    public Canvas ScorePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScorePanel.transform.position = Cube.transform.position;
        ScorePanel.transform.rotation = Cube.transform.rotation;
    }




}
