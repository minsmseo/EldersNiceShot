using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time = 30.0f;

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        /* some Text change
        double b = System.Math.Round(cntdnw, 2);
        UI controller ø¨∞·«ÿº≠ Text∞¥√º.text= b.toString(); «œ∏È µ 
        */
        if (cntdnw < 0)
        {
            Debug.Log("Time out");
        }
    }
}
