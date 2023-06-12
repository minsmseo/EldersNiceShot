using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool pause;
    public float remain_time = 0f;

    void Update()
    {
        if (remain_time > 0 && pause == false)
        {
            remain_time -= Time.deltaTime;
        }
        /* some Text change
        double b = System.Math.Round(cntdnw, 2);
        UI controller ø¨∞·«ÿº≠ Text∞¥√º.text= b.toString(); «œ∏È µ 
        */
        if (remain_time < 0)
        {
            Debug.Log("Time out");

            this.GetComponent<Timer>().enabled = false;
        }
    }
    public void TimerStart(float _time)
    {
        remain_time = _time;
    }

    public void PauseTimer()
    {
        pause = true;
    }

    public void ResumeTimer()
    {
        pause = false;
    }
}
