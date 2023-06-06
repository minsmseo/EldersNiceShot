using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour
{
    Rigidbody rigidbody;
    GameManager gamemanager;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        gamemanager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.IsSleeping())
        {
            disableThisScript();
        }
        if (this.gameObject.activeSelf == false)
        {
            this.GetComponent<MovementDetector>().enabled = false;
        }
    }

    void disableThisScript()
    {
        if (gamemanager.turnPhase == GameManager.phase.strike && gamemanager.balls[gamemanager.cur_ball-1] == this.gameObject)
        {
            gamemanager.turnPhase = GameManager.phase.done;
        }
        this.GetComponent<Ball>().last_loc = this.transform.position;
        this.GetComponent<MovementDetector>().enabled = false;
    }
}
