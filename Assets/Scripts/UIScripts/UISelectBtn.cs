using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.InputSystem;



public class UISelectBtn : MonoBehaviour
{
    public InputDeviceCharacteristics rightControllerCharacteristics, leftControllerCharacteristics;
    public Button  manualButton, backButton, closeButton, exitButton;
    public GameObject ManualPanel; 


    private Button[] UIButtons = new Button[4];

    private int selectNum = 0;
    private ColorBlock[] oldCol = new ColorBlock[4];
    private ColorBlock selectCol;

    //public Button btnPrefab;


    public void Start()
    {
        SetButtonArray();


        for (int i = 0; i < UIButtons.Length; i++)
        {
            oldCol[i] = UIButtons[selectNum].colors;
        }
        //oldCol에 각각의 col 저장

        selectCol = UIButtons[selectNum].colors;
        selectCol.normalColor = new Color(1f, 0f, 0f, 1f);
        UIButtons[selectNum].colors = selectCol;
        UIButtons[selectNum].gameObject.SetActive(true);
        //0번째 btn 색 바꾸고 시작 
    }


    public void SetButtonArray()
    {
        UIButtons[0] = manualButton;
        UIButtons[1] = backButton;
        UIButtons[2] = closeButton;
        UIButtons[3] = exitButton;        
    }

    private void Update()
    {

    }

    public void MoveJoyStick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 value = context.ReadValue<Vector2>();
            Debug.Log("Moving Joystick!");
            Debug.Log(value.y);
            if (value.y > 0.25)
            {
                ReturnOldBtnColor();
                MoveUp();
            }
            else if (value.y < 0.25)
            {
                ReturnOldBtnColor();
                MoveDown();
            }
        }

        //if (rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        //{
        //    if (position.y > 0.5f && !isThumbstickUp)
        //    {

        //        isThumbstickUp = true;
        //        ReturnOldBtnColor();
        //        MoveUp();           
        //    }
        //    else if (position.y < -0.5f && !isThumbstickDown)
        //    {

        //        isThumbstickDown = true;
        //        ReturnOldBtnColor();
        //        MoveDown();

        //    }
        //    else if (position.y >= -0.5f && position.y <= 0.5f)
        //    {
        //        isThumbstickUp = false;
        //        isThumbstickDown = false;
        //    }
        //}
    }
    public void PressButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
            if (ManualPanel.activeSelf)
            {
                ManualPanel.SetActive(false);
                return;
            }
            UIButtons[selectNum].onClick.Invoke();
            Debug.Log("Button onClick!");
        }
    }

 
    private void ReturnOldBtnColor()
    {
        int oldNum = selectNum;
        UIButtons[oldNum].colors = oldCol[oldNum];
    }
    private void MoveUp()
    {
        selectNum += UIButtons.Length;
        selectNum--;
        selectNum %= UIButtons.Length;

        selectCol.normalColor = new Color(1f, 0f, 0f, 1f);
        UIButtons[selectNum].colors = selectCol;
    }

    private void MoveDown()
    {
        selectNum++;
        selectNum %= UIButtons.Length;
        selectCol.normalColor = new Color(1f, 0f, 0f, 1f);
        UIButtons[selectNum].colors = selectCol;
    }
}

