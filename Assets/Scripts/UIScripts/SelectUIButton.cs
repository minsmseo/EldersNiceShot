using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class SelectUIButton : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics = InputDeviceCharacteristics.Right & InputDeviceCharacteristics.Controller;
    private InputDevice targetDevice;

    public Button settingButton;
    public Button manualButton;
    public Button backButton;
    public Button exitButton;
    private Button[] UIButtons = new Button[4];
    private int selectNum = 0;
    private ColorBlock preCol;

    private bool isThumbstickUp = false;
    private bool isThumbstickDown = false;
    

    public void Awake()
    {
        TryInitialize();
        SetButtonArray();
        preCol = UIButtons[selectNum].colors;
        preCol.normalColor = UIButtons[selectNum].colors.normalColor;

    }

    public void SetButtonArray()
    {
        UIButtons[0] = settingButton;
        UIButtons[1] = manualButton;
        UIButtons[2] = backButton;
        UIButtons[3] = exitButton;

    }


    private void TryInitialize()
    {
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, inputDevices);

        if (inputDevices.Count > 0)
        {
            targetDevice = inputDevices[0];
        }
    }

    private void Update()
    {
        MpveUpDown();
        ChooseButton();
    }

    private void MpveUpDown()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {


            if (position.y > 0.5f && !isThumbstickUp)
            {
                selectNum--;
                isThumbstickUp = true;

                ChangeButton();

            }
            else if (position.y < -0.5f && !isThumbstickDown)
            {
                selectNum++;
                isThumbstickDown = true;

                ChangeButton();


            }
            else if (position.y >= -0.5f && position.y <= 0.5f)
            {
                isThumbstickUp = false;
                isThumbstickDown = false;

            }
        }
    }

    private void ChooseButton()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))
        {
            if (BButton == true)
            {
                UIButtons[selectNum].onClick.Invoke();
            }
        }
    }

    private void ChangeButton()
    {
        if (selectNum < 0)
        {
            selectNum += 4;

        }
        selectNum %= 4;


        GetBack();
        ColorBlock col = UIButtons[selectNum].colors;
        col.normalColor = new Color(0, 0, 0);
        UIButtons[selectNum].colors = col;
    }


    private void GetBack()
    {
        int preNum = selectNum -1;
        int nextNum = selectNum + 1;

        if(preNum <0) { preNum = 3; }
        else if ( nextNum > 3) { nextNum = 0; }
        UIButtons[preNum].colors = preCol;
        UIButtons[nextNum].colors = preCol;
    }
}