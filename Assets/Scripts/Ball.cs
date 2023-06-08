using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int ball_number;
    public int target_gate;
    public int score;
    public bool out_ball;
    public bool complete;
    public Vector3 last_loc;

    // Start is called before the first frame update
    void Start()
    {
        out_ball = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Hammer"))
        {
            GameManager.Instance.turnPhase = GameManager.phase.strike;
            CheckThisBallIsMoving();
        }
    }

    void CheckThisBallIsMoving()
    {
        this.GetComponent<MovementDetector>().enabled = true;
    }

    void SaveLocation()
    {
        last_loc = this.transform.position;
    }
}
