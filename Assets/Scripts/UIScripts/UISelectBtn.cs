using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;



public class UISelectBtn : MonoBehaviour
{
    public InputDeviceCharacteristics rightControllerCharacteristics, leftControllerCharacteristics;
    private InputDevice rightDevice, leftDevice;
    public Button settingButton, manualButton, backButton, closeButton, exitButton;

    private Button[] UIButtons = new Button[5];

    private int selectNum = 0;
    private ColorBlock[] oldCol = new ColorBlock[5];
    private ColorBlock selectCol;

    private bool isThumbstickUp = false;
    private bool isThumbstickDown = false;

    //public Button btnPrefab;


    public void Awake()
    {
        TryInitialize();
        SetButtonArray();


        for (int i = 0; i < UIButtons.Length; i++)
        {
            oldCol[i] = UIButtons[selectNum].colors;
        }
        //oldCol에 각각의 col 저장

        selectCol = UIButtons[selectNum].colors;
        selectCol.normalColor = new Color(1f, 0f, 0f, 1f);
        UIButtons[selectNum].colors = selectCol;
        //0번째 btn 색 바꾸고 시작 
    }


    public void SetButtonArray()
    {
        UIButtons[0] = settingButton;
        UIButtons[1] = manualButton;
        UIButtons[2] = backButton;
        UIButtons[3] = closeButton;
        UIButtons[4] = exitButton;
    }



    private void TryInitialize()
    {
        List<InputDevice> RinputDevices = new List<InputDevice>();
        List<InputDevice> LinputDevices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, RinputDevices);
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, LinputDevices);

        if (RinputDevices.Count > 0)
        {
            rightDevice = RinputDevices[0];
        }

        if (LinputDevices.Count > 0)
        {
            leftDevice = LinputDevices[0];
        }
    }



    private void Update()
    {
        MoveJoyStick();
        PressButton();
    }

    private void MoveJoyStick()
    {
        if (rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            if (position.y > 0.5f && !isThumbstickUp)
            {
               
                isThumbstickUp = true;
                ReturnOldBtnColor();
                MoveUp();           
            }
            else if (position.y < -0.5f && !isThumbstickDown)
            {
               
                isThumbstickDown = true;
                ReturnOldBtnColor();
                MoveDown();
                
            }
            else if (position.y >= -0.5f && position.y <= 0.5f)
            {
                isThumbstickUp = false;
                isThumbstickDown = false;
            }
        }
    }

    private void PressButton()
    {
        if (leftDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool YButton))
        {
            if (YButton == true)
            {
                SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
                UIButtons[selectNum].onClick.Invoke();
            }
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

