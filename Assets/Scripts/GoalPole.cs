using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPole : MonoBehaviour
{
    public int gate_number;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (other.GetComponent<Ball>().target_gate == gate_number)
            {
                other.GetComponent<Ball>().target_gate++;
                other.GetComponent<Ball>().complete = true;
                other.gameObject.SetActive(false);
            }
        }
        GameManager.Instance.UpdateScore();
        if (GameManager.Instance.complete_balls == GameManager.Instance.number_of_players)
        {
            GameManager.Instance.EndGame();
        }
    }
}
