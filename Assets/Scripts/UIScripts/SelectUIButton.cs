using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class SelectUIButton : MonoBehaviour
{
    //public AudioSource audioSource = AddComponent<AudioSource>();
    public InputDeviceCharacteristics rightControllerCharacteristics;
    public InputDeviceCharacteristics leftControllerCharacteristics;
    private InputDevice rightDevice;
    private InputDevice leftDevice;

    public Button settingButton;
    public Button manualButton;
    public Button backButton;
    public Button exitButton;

    //public Button btnPrefab; 

    private Button[] UIButtons = new Button[4];
 

    private int selectNum = 0;
    //private int oldNum;
    private ColorBlock col;

    private bool isThumbstickUp = false;
    private bool isThumbstickDown = false;
    

    public void Awake()
    {
        TryInitialize();
        SetButtonArray();
        SetButtonSound();

        //preCol ǥ��
        //col = btnPrefab.colors;
        col = UIButtons[selectNum].colors;
        col.normalColor = UIButtons[selectNum].colors.normalColor;

    }

    public void SetButtonArray()
    {
        UIButtons[0] = settingButton;
        UIButtons[1] = manualButton;
        UIButtons[2] = backButton;
        UIButtons[3] = exitButton;

        
    }

    private void SetButtonSound()
    {
        for (int i = 0; i < UIButtons.Length; i++)
        {
            UIButtons[i].onClick.AddListener(PlayButtonClickSound);
        }
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
        MpveUpDown();
        PressButton();
    }

    private void PlayButtonClickSound()
    {
        // SoundManager �ν��Ͻ��� ������
        SoundManager soundManager = SoundManager.Instance;

        // SoundManager�� ����Ͽ� ��ư ȿ���� ���
        soundManager.PlayEffectSound(eSFX.eUI_Button);
    }

    private void MpveUpDown()
    {
        if (rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {


            if (position.y > 0.5f && !isThumbstickUp)
            {
                
                selectNum--;
                isThumbstickUp = true;

                ChangeButton();
                //��ư �ٲٱ� 

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

    private void PressButton()
    {
        if (leftDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool YButton))
        {
            if (YButton == true)
            {
      
                UIButtons[selectNum].onClick.Invoke();

            }
        }
    }

    private void ChangeButton()
    {
        //��ư �ٲٱ� 


        if (selectNum < 0)
        {
            selectNum += 4;

        }
        selectNum %= 4;

        //audioSource.Play();


        GetBack(); // ���� �ֵ� �������� 

        // ���� selectNum�� �� �ٲٱ� 
        ColorBlock col = UIButtons[selectNum].colors;
        //���� select Num�� colors �Ӽ� col�� ����

        col.normalColor = new Color(0, 0, 0);
        //col.�� normalColr ����

        UIButtons[selectNum].colors = col;
        //���� selecNum color -> col == ���õǾ������� ���� ���� ��





        //UIButtons[selectNum].colors.normalColor = col.selectedColor;




    }

    // ���� selectNum �� �Ʒ� ��ư ������ �����ϰ� �ٲ��ִ� �Լ�
    private void GetBack()
    {
        int preNum = selectNum -1;
        int nextNum = selectNum + 1;

        if(preNum <0) { preNum = 3; }
        else if ( nextNum > 3) { nextNum = 0; }
        // ���� 


        UIButtons[preNum].colors = col;
        UIButtons[nextNum].colors = col;
        //preCol = UIButtons[selectNum].colors;
    }


}