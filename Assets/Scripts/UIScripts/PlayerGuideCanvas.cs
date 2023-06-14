using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGuideCanvas : MonoBehaviour
{
    private static PlayerGuideCanvas _instance;
    public static PlayerGuideCanvas Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(PlayerGuideCanvas)) as PlayerGuideCanvas;
                if (_instance == null)
                {
                    Debug.Log("No Singleton Object");
                }
            }
            return _instance;
        }
    }
    // Start is called before the first frame update

    public TextMeshProUGUI GuideText;
    public TextMeshProUGUI BallText;
    public TextMeshProUGUI TurnGuideText;
    public TextMeshProUGUI[] ScoresText;
    public TextMeshProUGUI[] TotalScoresText;

    private string[] GuideTextArray = new string[8];
    private string[] TurnTextArray = new string[2] { "RED", "WHITE" };

    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        SetTextArray();
    }

    void SetTextArray()
    {
        GuideTextArray[0] = "B버튼을 눌러 게임을 시작하세요"; //lobby
        GuideTextArray[1] = "공을 타격할 준비가 되었다면 A키를 누르세요"; //start
        GuideTextArray [2] = "공을 타격하세요!"; //ready
        GuideTextArray [3] = "공이 이동중입니다. . ."; //strike
        GuideTextArray [4] = "기기를 다음 사람에게 넘겨주고\n준비가 되었다면 B키를 눌러주세요"; //done
        GuideTextArray[5] = "Red Team 승리!";
        GuideTextArray[6] = "White Team 승리!";
        GuideTextArray[7] = "무승부!";
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeGuideText(int i)
    {
        GuideText.text = GuideTextArray[i];
    }

    public void ChangeGuideTextColor(Color color)
    {
        GuideText.color = color;
    }

    public void ChangeTurnGuideText()
    {
        if (GameManager.Instance.cur_ball == 0)
        {
            TurnGuideText.text = "";
        }
        else if (GameManager.Instance.cur_ball % 2 == 1)
        {
            TurnGuideText.text = TurnTextArray[0] + " Team의 차례";
            TurnGuideText.color = Color.red;
            // Ex) RED Player의 차례입니다!
        }
        else
        {
            TurnGuideText.text = TurnTextArray[1] + " Team의 차례";
            TurnGuideText.color = Color.white;
            // Ex) BLUE Player의 차례입니다!
        }
    }
}
