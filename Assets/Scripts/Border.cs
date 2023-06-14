using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public bool isBorderlineX;
    public float outline;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") & GameManager.Instance.turnPhase == GameManager.phase.strike)
        {
            other.GetComponent<MovementDetector>().disableThisScript();
            if (isBorderlineX == true)
            {
                other.GetComponent<Ball>().last_loc = new Vector3(outline, 0.01f, other.transform.localPosition.z);
            }
            else
            {
                other.GetComponent<Ball>().last_loc = new Vector3(other.transform.localPosition.x, 0.01f, outline);
            }
            if (other.GetComponent<Ball>().target_gate == 1)
            {
                other.GetComponent<Ball>().last_loc = GameManager.Instance.start_loc;
            }
            other.gameObject.SetActive(false);
        }
    }
}
