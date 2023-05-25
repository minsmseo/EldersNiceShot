using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public int cur_ball; // ���� ������ ���� ��ȣ
    public int playing_balls; // ���� �÷������� ���� ����
    enum phase { start, ready, strike, done, setting };
    phase turnPhase; // 0 : �ʱ�, 1 : ��ƽȰ��ȭ, 2 : �� Ÿ��, 3 : �� ������ �Ϸ�(�� �ѱ�� ����), 5 : ����
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
