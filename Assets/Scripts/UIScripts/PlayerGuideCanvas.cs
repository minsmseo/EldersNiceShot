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
    //차례 알려주는 string 배열 
    private int TurnCount = 0;
    private int BallNum;

    
    private void Awake()
    {
        SetTextArray();
    }

    void SetTextArray()
    {
        GuideTextArray[0] = "공을 타격할 준비가 되었다면 A키를 누르세요"; //start
        GuideTextArray [1] = "순서에 맞는 공을 타격하세요"; //ready
        GuideTextArray [2] = " "; //strike
        GuideTextArray [3] = "기기를 다음 사람에게 넘겨주고\n준비가 되었다면 X키를 눌러주세요"; //done

    }
    // Update is called once per frame
    void Update()
    {
        ChangeText();

    }


    //Text변경 함수
    void ChangeText()
    {
        //GuideText 변경 
        GuideText.text = GuideTextArray[0];
        //GuideText.text = GuideTextArray[i];

        BallText.text = "공 번호:";
        //BalleText.text = "공번호" + BallNum;
        //BallNum은 일단 선언만 해두었습니다
        //ex) 공번호 : 1 

        //공을 치고나서 count++; 코드를 넣으려고 했는데
        //언제 넣어야할지 모르겠어서 일단 빼두었습니다
        if(TurnCount%2 ==0)
        {
            TurnGuideText.text = TurnTextArray[0] + "Player의 차례입니다!";
            // Ex) RED Player의 차례입니다!
        }
        else
        {
            TurnGuideText.text = TurnTextArray[1] + "Player의 차례입니다!";
            // Ex) BLUE Player의 차례입니다!
        }

    }

}
