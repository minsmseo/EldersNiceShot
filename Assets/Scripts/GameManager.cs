using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public int cur_ball; // 현재 차례인 공의 번호
    public int playing_balls; // 현재 플레이중인 공의 개수
    enum phase { start, ready, strike, done, setting };
    phase turnPhase; // 0 : 초기, 1 : 스틱활성화, 2 : 공 타격, 3 : 공 움직임 완료(턴 넘기기 직전), 5 : 설정
    public int sparkStrike;
    public Hammer hammer;
    private GameObject hammer_head;
    private GameObject hammer_stick;

    // Start is called before the first frame update
    void Start()
    {
        cur_ball = 1;
        turnPhase = phase.start;
        hammer_head = hammer.hammer_head;
        hammer_stick = hammer.hammer_stick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onToggleStick(InputAction.CallbackContext context)
    {
        if (turnPhase == phase.start)
        {
            hammer_head.GetComponent<BoxCollider>().isTrigger = false;
            hammer_stick.GetComponent<CapsuleCollider>().isTrigger = false;
            turnPhase = phase.ready;
        }
        else if (turnPhase == phase.ready)
        {
            hammer_head.GetComponent<BoxCollider>().isTrigger = true;
            hammer_stick.GetComponent<CapsuleCollider>().isTrigger = true;
            turnPhase = phase.start;
        }
    }
}
