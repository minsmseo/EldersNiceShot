using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (_instance == null)
                {
                    Debug.Log("No Singleton Object");
                }
            }
            return _instance;
        }
    }
    public int cur_ball; // 현재 차례인 공의 번호
    public enum phase { start, ready, strike, done, setting, lobby };
    public phase turnPhase; // 0 : 초기, 1 : 스틱활성화, 2 : 공 타격, 3 : 공 움직임 완료(턴 넘기기 직전), 5 : 설정
    public Vector3 start_loc;
    public GameObject[] balls;
    public GameObject hammer;
    public Timer timer;
    public int[] score;
    public int number_of_players;
    public int complete_balls;
    public int red_score;
    public int blue_score;

    void Awake()
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
    }

    // Start is called before the first frame update
    void Start()
    {
        turnPhase = phase.lobby;
        cur_ball = 0;
        PlayerGuideCanvas.Instance.ChangeGuideText(0);
        PlayerGuideCanvas.Instance.ChangeTurnGuideText();
        PlayerGuideCanvas.Instance.BallText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("reset setting");
        cur_ball = 1;
        turnPhase = phase.start;
        PlayerGuideCanvas.Instance.ChangeGuideText(1);
        PlayerGuideCanvas.Instance.ChangeTurnGuideText();
        PlayerGuideCanvas.Instance.BallText.text = cur_ball + "번공 차례";
        for (int i = 0; i < number_of_players; i++)
        {
            score[i] = 0;
            balls[i].GetComponent<Ball>().target_gate = 1;
            balls[i].GetComponent<Ball>().last_loc = start_loc; //초기 위치좌표로 수정
            balls[i].GetComponent<Ball>().out_ball = true;
            balls[i].GetComponent<Rigidbody>().isKinematic = true;
            balls[i].gameObject.SetActive(false);
        }
        UpdateScore();
        // 타이머 초기화
        timer.TimerStart(600f);
        balls[0].GetComponent<Ball>().out_ball = false;
        balls[0].transform.rotation = Quaternion.Euler(0, 0, 0);
        balls[0].transform.localPosition = balls[0].GetComponent<Ball>().last_loc;
        balls[0].gameObject.SetActive(true);
    }

    public void UpdateScore()
    {
        int i = 0;
        red_score = 0;
        blue_score = 0;
        while (i < number_of_players)
        {
            PlayerGuideCanvas.Instance.ScoresText[i].text = score[i].ToString();
            if (i % 2 == 0)
            {
                red_score += score[i];
                PlayerGuideCanvas.Instance.TotalScoresText[0].text = red_score.ToString();
            }
            else
            {
                blue_score += score[i];
                PlayerGuideCanvas.Instance.TotalScoresText[1].text = blue_score.ToString();
            }
            i++;
        }
    }

    public void OnToggleStick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (turnPhase == phase.start)
            {
                balls[cur_ball - 1].GetComponent<Rigidbody>().isKinematic = false;
                turnPhase = phase.ready;
                hammer.SetActive(true);
                timer.pause = false;
                PlayerGuideCanvas.Instance.ChangeGuideText(2);
            }
            else if (turnPhase == phase.ready)
            {
                balls[cur_ball - 1].GetComponent<Rigidbody>().isKinematic = true;
                turnPhase = phase.start;
                hammer.SetActive(false);
                PlayerGuideCanvas.Instance.ChangeGuideText(1);
            }
        }
    }

    public void OnNextTurn(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (turnPhase == phase.done)
            {
                if (timer.remain_time <= 0f)
                {
                    EndGame();
                    return;
                }
                cur_ball++;
                if (cur_ball > number_of_players)
                {
                    cur_ball = 1;
                }
                while (balls[cur_ball - 1].GetComponent<Ball>().complete == true)
                {
                    cur_ball++;
                    if (cur_ball > number_of_players)
                    {
                        cur_ball = 1;
                    }
                }

                turnPhase = phase.start;
                GameObject current_ball = balls[cur_ball-1];
                PlayerGuideCanvas.Instance.ChangeGuideText(1);
                PlayerGuideCanvas.Instance.ChangeTurnGuideText();
                PlayerGuideCanvas.Instance.BallText.text = cur_ball + "번공 차례";
                
                for (int i = 0; i < number_of_players; i++)
                {
                    balls[i].gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                current_ball.GetComponent<Rigidbody>().isKinematic = false;
                current_ball.transform.rotation = Quaternion.Euler(0, 0, 0);
                current_ball.transform.localPosition = current_ball.GetComponent<Ball>().last_loc;
                current_ball.SetActive(true);
            }
            else
            {
                Debug.Log("It's not done phase");
            }
        }
    }

    public void OnTestStart(InputAction.CallbackContext context)
    {
        if (context.started & turnPhase == phase.lobby)
        {
            Debug.Log("start game");
            StartGame();
        }
    }

    public void EndGame()
    {
        for (int i = 0; i < number_of_players; i++)
        {
            balls[i].gameObject.SetActive(false);
        }

        if (red_score > blue_score)
        {
            //RedTeamWin()
        }
        else if (blue_score >red_score)
        {
            //BlueTeamWin()
        }
        else
        {
            //Draw()
        }
        cur_ball = 0;
        turnPhase = phase.lobby;
        PlayerGuideCanvas.Instance.ChangeGuideText(0);
    }

    public void ResetGame()
    {
        EndGame();
        StartGame();
    }
}
