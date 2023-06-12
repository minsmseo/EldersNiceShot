using UnityEngine;
using TMPro;

public class TestScorePanel: MonoBehaviour
{
   

   // public GameObject pauseButton;
    public TextMeshProUGUI scoreText;
    public GameObject mainPanel;
    public GameObject scorePanel;


    /**
     화면 상단 우측에 보이는 스코어 텍스트 밑 일시정지 버튼을 클릭했을 때 수행할 동작
     */


    //public void pause_btn_clicked()
    //{
    //    mainPanel.SetActive(true);
    //    scorePanel.SetActive(false);
    //}



    /**
     화면 우측 상단에 있는 스코어 텍스트를 업데이트하는 함수
     */
    private void change_scoreText(string score)
    {
        scoreText.text = "score: " + score;

    }

    public void change_scoreText(int score)
    {
        change_scoreText(score.ToString());
    }
}
