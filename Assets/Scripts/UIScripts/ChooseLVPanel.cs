using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseLVPanel : MonoBehaviour
{

    public GameObject chooseLVPanel, selectPanel;
    public GameObject FirstPanel;
    public GameObject ManaulCube;

    public GameObject stageImage;
    private int currentLevel;

    public Button level1Button, level2Button, exitButton;
    public Button startButton, lobbyManualButton, closeManaulButton;



    // Start is called before the first frame update
    void Awake()
    {


        FirstPanel.SetActive(true);
        chooseLVPanel.SetActive(false);
        selectPanel.SetActive(false);
        ManaulCube.SetActive(false);



        lobbyManualButton.onClick.AddListener(ShowManual);
        closeManaulButton.onClick.AddListener(CloseManaul);
        startButton.onClick.AddListener(ReadyToPlay);
        level1Button.onClick.AddListener(choose_level1);
        level2Button.onClick.AddListener(choose_level2);
        exitButton.onClick.AddListener(buttonExit_clicked);




    }


    public void ShowManual()
    {
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
        ManaulCube.SetActive(true);
        exitButton.gameObject.SetActive(false);
        lobbyManualButton.gameObject.SetActive(false);
        closeManaulButton.gameObject.SetActive(true);
    }

    public void CloseManaul()
    {
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
        ManaulCube.SetActive(false);
        exitButton.gameObject.SetActive(true);
        lobbyManualButton.gameObject.SetActive(true);
        closeManaulButton.gameObject.SetActive(false);

    }


    public void ReadyToPlay()
    {
        FirstPanel.SetActive(false);
        chooseLVPanel.SetActive(true);
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);

    }





    public void choose_level1()
    {
        selectPanel.SetActive(true);
        chooseLVPanel.SetActive(false);
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
    }

    public void choose_level2()
    {
        selectPanel.SetActive(true);
        chooseLVPanel.SetActive(false);
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
    }



    public void buttonExit_clicked()
    {

        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }


}

