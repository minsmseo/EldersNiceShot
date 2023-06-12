using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") & GameManager.Instance.turnPhase == GameManager.phase.strike)
        {
            other.GetComponent<Ball>().last_loc = new Vector3(other.transform.position.x, 0.01f, other.transform.position.z);
            other.GetComponent<Ball>().out_ball = true;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.SetActive(false);
            if (GameManager.Instance.cur_ball == other.GetComponent<Ball>().ball_number)
            {
                if (GameManager.Instance.turnPhase == GameManager.phase.strike)
                {
                    GameManager.Instance.turnPhase = GameManager.phase.done;
                }
            }
        }
    }
}
