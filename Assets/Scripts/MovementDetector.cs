using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour
{
    Rigidbody rigidbody;
    GameManager gamemanager;
    float time;

    // Start is called before the first frame update
    void Awake()
    {
        time = 0;
        rigidbody = GetComponent<Rigidbody>();
        gamemanager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (rigidbody.IsSleeping())
        {
            disableThisScript();
        }
        if (time > 3f & rigidbody.velocity.magnitude < 0.1f)
        {
            disableThisScript();
        }
    }

    public void disableThisScript()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        if (gamemanager.turnPhase == GameManager.phase.strike && gamemanager.balls[gamemanager.cur_ball-1] == gameObject)
        {
            gamemanager.timer.pause = true;
            gamemanager.turnPhase = GameManager.phase.done;
            PlayerGuideCanvas.Instance.ChangeGuideText(4);
        }
        if (GetComponent<Ball>().target_gate == 1)
        {
            GetComponent<Ball>().last_loc = gamemanager.start_loc;
            gameObject.SetActive(false);
        }
        else
        {
            GetComponent<Ball>().SaveLocation();
        }
        GetComponent<MovementDetector>().enabled = false;
        time = 0;
    }
}
