using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGuideCanvas : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI GuideText;
    public TextMeshProUGUI BallText;
    public TextMeshProUGUI TurnGuideText;

    private string[] GuideTextArray = new string[4];
    private string[] TurnTextArray = new string[2] { "RED", "BLUE" };
    //���� �˷��ִ� string �迭 
    private int TurnCount = 0;
    private int BallNum;

    
    private void Awake()
    {
        SetTextArray();
    }

    void SetTextArray()
    {
        GuideTextArray[0] = "���� Ÿ���� �غ� �Ǿ��ٸ� AŰ�� ��������"; //start
        GuideTextArray [1] = "������ �´� ���� Ÿ���ϼ���"; //ready
        GuideTextArray [2] = " "; //strike
        GuideTextArray [3] = "��⸦ ���� ������� �Ѱ��ְ�\n�غ� �Ǿ��ٸ� XŰ�� �����ּ���"; //done

    }
    // Update is called once per frame
    void Update()
    {
        ChangeText();

    }


    //Text���� �Լ�
    void ChangeText()
    {
        //GuideText ���� 
        GuideText.text = GuideTextArray[0];
        //GuideText.text = GuideTextArray[i];

        BallText.text = "�� ��ȣ:";
        //BalleText.text = "����ȣ" + BallNum;
        //BallNum�� �ϴ� ���� �صξ����ϴ�
        //ex) ����ȣ : 1 

        //���� ġ���� count++; �ڵ带 �������� �ߴµ�
        //���� �־������ �𸣰ھ �ϴ� ���ξ����ϴ�
        if(TurnCount%2 ==0)
        {
            TurnGuideText.text = TurnTextArray[0] + "Player�� �����Դϴ�!";
            // Ex) RED Player�� �����Դϴ�!
        }
        else
        {
            TurnGuideText.text = TurnTextArray[1] + "Player�� �����Դϴ�!";
            // Ex) BLUE Player�� �����Դϴ�!
        }

    }

}
