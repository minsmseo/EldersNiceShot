using UnityEngine;
using TMPro;

public class TestScorePanel: MonoBehaviour
{
   

   // public GameObject pauseButton;
    public TextMeshProUGUI scoreText;
    public GameObject mainPanel;
    public GameObject scorePanel;


    /**
     ȭ�� ��� ������ ���̴� ���ھ� �ؽ�Ʈ �� �Ͻ����� ��ư�� Ŭ������ �� ������ ����
     */


    //public void pause_btn_clicked()
    //{
    //    mainPanel.SetActive(true);
    //    scorePanel.SetActive(false);
    //}



    /**
     ȭ�� ���� ��ܿ� �ִ� ���ھ� �ؽ�Ʈ�� ������Ʈ�ϴ� �Լ�
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
