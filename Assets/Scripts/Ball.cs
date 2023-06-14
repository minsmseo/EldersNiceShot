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


    void DisableHammer()
    {
        GameManager.Instance.hammer.SetActive(false);
    }
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
        if (collision.transform.CompareTag("Hammer") & GameManager.Instance.turnPhase == GameManager.phase.ready)
        {
            if (ball_number == GameManager.Instance.cur_ball)
                Invoke("DisableHammer", 0.5f);
                GameManager.Instance.turnPhase = GameManager.phase.strike;
                CheckThisBallIsMoving();
                for (int i = 0; i < GameManager.Instance.number_of_players; i++)
                {
                    GameManager.Instance.balls[i].GetComponent<Rigidbody>().isKinematic = false;
                }
        }
        if (collision.transform.CompareTag("Ball"))
        {
            CheckThisBallIsMoving();
        }
    }

    void CheckThisBallIsMoving()
    {
        this.GetComponent<MovementDetector>().enabled = true;
    }

    public void SaveLocation()
    {
        last_loc = new Vector3(this.transform.localPosition.x, 0f, this.transform.localPosition.z);
    }
}
