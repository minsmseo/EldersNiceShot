using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time = .0f;

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        /* some Text change
        double b = System.Math.Round(cntdnw, 2);
        UI controller �����ؼ� Text��ü.text= b.toString(); �ϸ� ��
        */
        if (time < 0)
        {
            Debug.Log("Time out");
            time = 0f;
        }
    }
    public void TimerStart(float _time)
    {
        time = _time;
    }
}
