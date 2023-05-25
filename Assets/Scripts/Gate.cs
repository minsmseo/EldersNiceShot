using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Vector3 front;
    public Vector3 back;
    public bool gateAxisIsX;
    public bool isFrontPositive;
    public Vector3 point_in;
    public Vector3 point_out;
    public int gate_number;
    Ball passed_ball;
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
        if (other.tag == "Ball")
        {
            point_in = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("something Detected");
        if (other.tag == "Ball")
        {
            point_out = other.transform.position;
            passed_ball = other.GetComponent<Ball>();
            PassingBall();
        }
    }

    private void PassingBall()
    {
        float val_in;
        float val_out;
        if (gateAxisIsX == true) // 게이트 통과 방향이 x축일때
        {
            val_in = point_in.x;
            val_out = point_out.x;
        }
        else // 게이트 통과 방향이 z축일때
        {
            val_in = point_in.z;
            val_out = point_out.z;
        }

        if (val_in > val_out) //게이트 통과방향이 + -> -일때
        {
            if (isFrontPositive == true)
            {
                CheckPass();
                ResetValue();
            }

            else
            {
                ResetValue();
            }
        }

        else //게이트 통과방향이 - -> +일때
        {
            if (isFrontPositive == false)
            {
                CheckPass();
                ResetValue();
            }

            else
            {
                ResetValue();
            }
        }
    }

    private void CheckPass()
    {
        Debug.Log("Right direction!");
        if (passed_ball.target_gate == gate_number)
        {
            passed_ball.target_gate++;
            passed_ball.score++;
        }
        
    }

    private void ResetValue()
    {
        Debug.Log("Reset Value");
        point_in = new Vector3(0, 0, 0);
        point_out = new Vector3(0, 0, 0);
    }
}
