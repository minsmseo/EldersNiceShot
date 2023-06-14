using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    public bool pause;
    public float remain_time = 0f;
    public TextMeshProUGUI timerText;



    void Update()
    {
        if (remain_time > 0 && pause == false)
        {
            remain_time -= Time.deltaTime;
        }

        /* some Text change
        double b = System.Math.Round(cntdnw, 2);
        UI controller 연결해서 Text객체.text= b.toString(); 하면 됨
        */


        //text 출력
        double time  = System.Math.Round(remain_time, 0);
        int minutes = Mathf.FloorToInt(remain_time / 60);
        int seconds = Mathf.FloorToInt(remain_time % 60);
        timerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");



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
