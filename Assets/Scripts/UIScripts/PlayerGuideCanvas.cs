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
        GuideTextArray[0] = "B��ư�� ���� ������ �����ϼ���"; //lobby
        GuideTextArray[1] = "���� Ÿ���� �غ� �Ǿ��ٸ� AŰ�� ��������"; //start
        GuideTextArray [2] = "���� Ÿ���ϼ���!"; //ready
        GuideTextArray [3] = "���� �̵����Դϴ�. . ."; //strike
        GuideTextArray [4] = "��⸦ ���� ������� �Ѱ��ְ�\n�غ� �Ǿ��ٸ� BŰ�� �����ּ���"; //done
        GuideTextArray[5] = "Red Team �¸�!";
        GuideTextArray[6] = "White Team �¸�!";
        GuideTextArray[7] = "���º�!";
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
            TurnGuideText.text = TurnTextArray[0] + " Team�� ����";
            TurnGuideText.color = Color.red;
            // Ex) RED Player�� �����Դϴ�!
        }
        else
        {
            TurnGuideText.text = TurnTextArray[1] + " Team�� ����";
            TurnGuideText.color = Color.white;
            // Ex) BLUE Player�� �����Դϴ�!
        }
    }
}
