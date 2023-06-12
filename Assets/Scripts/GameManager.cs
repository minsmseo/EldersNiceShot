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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        if (turnPhase == phase.lobby)
        {
            Debug.Log("reset setting");
            cur_ball = 1;
            turnPhase = phase.start;
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
            balls[0].transform.position = balls[0].GetComponent<Ball>().last_loc;
            balls[0].gameObject.SetActive(true);
        }
    }

    public void UpdateScore()
    {
        int i = 0;
        red_score = 0;
        blue_score = 0;
        while (i < number_of_players)
        {
            if (i % 2 == 0)
            {
                red_score += score[i];
            }
            else
            {
                blue_score += score[i];
            }
            i++;
        }
        Debug.Log($"Ball01 : {score[0]}, Ball02 : {score[1]}, Ball03 : {score[2]}, Ball04 : {score[3]}");
    }

    public void OnToggleStick(InputAction.CallbackContext context)
    {
        if (turnPhase == phase.start)
        {
            balls[cur_ball-1].GetComponent<Rigidbody>().isKinematic = false;
            turnPhase = phase.ready;
        }
        else if (turnPhase == phase.ready)
        {
            balls[cur_ball - 1].GetComponent<Rigidbody>().isKinematic = true;
            turnPhase = phase.start;
        }
    }

    public void OnNextTurn(InputAction.CallbackContext context)
    {
        if (timer.remain_time <= 0f)
        {
            EndGame();
            return;
        } 
        if (turnPhase == phase.done)
        {
            cur_ball++;
            if (cur_ball > number_of_players)
            {
                cur_ball = 1;
            }
            while(balls[cur_ball - 1].GetComponent<Ball>().complete == true)
            {
                cur_ball++;
                if (cur_ball > number_of_players)
                {
                    cur_ball = 1;
                }
            }

            turnPhase = phase.start;
            timer.pause = false;
            if (balls[cur_ball - 1].GetComponent<Ball>().out_ball == true)
            {
                balls[cur_ball - 1].transform.rotation = Quaternion.Euler(0, 0, 0);
                balls[cur_ball - 1].transform.position = balls[cur_ball - 1].GetComponent<Ball>().last_loc;
                balls[cur_ball - 1].SetActive(true);
                balls[cur_ball - 1].GetComponent<Ball>().out_ball = false;
            }
            for (int i = 0; i < number_of_players; i++)
            {
                balls[i].GetComponent<Rigidbody>().isKinematic = true;
            }
            hammer.SetActive(true);
        }
        else
        {
            Debug.Log("It's not done phase");
        }
    }

    public void OnTestStart(InputAction.CallbackContext context)
    {
        Debug.Log("start game");
        StartGame();
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

        turnPhase = phase.lobby;
    }
}
