using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseLVPanel : MonoBehaviour
{

    //public GameObject buttonExit;
    //public GameObject level1, level2;
    public GameObject chooseLVPanel, selectPanel;
    public GameObject FirstPanel;

    public GameObject stageImage;
    private int currentLevel;

    public Button level1Button, level2Button, exitButton;
    public Button startButton, lobbyManualButton;



    //private Image stageImageImageComponent;
    //private Sprite[] previewSprites;


    // Start is called before the first frame update
    void Awake()
    {

        //if (stageImage != null)
        //{
        //    //이미지가 없다면 이미지 컴포턴트에서 가져온다 
        //    stageImageImageComponent = stageImage.GetComponent<Image>();
        //}
        //stageCount = 2;
        //previewSprites = new Sprite[stageCount];
        //currentStage = 1;


        FirstPanel.SetActive(true);
        chooseLVPanel.SetActive(false);
        selectPanel.SetActive(false);

        //level1Button = level1.GetComponent<Button>();
        //level2Button = level2.GetComponent<Button>();
        lobbyManualButton.onClick.AddListener(ShowManual);
        startButton.onClick.AddListener(GameStart);
        level1Button.onClick.AddListener(choose_level1);
        level2Button.onClick.AddListener(choose_level2);
        exitButton.onClick.AddListener(buttonExit_clicked);




    }


    public void ShowManual()
    {
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
        chooseLVPanel.SetActive(false);
    }


    //public void stageimage_clicked()
    //{

    //}

    public void GameStart()
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



    //private void set_stage_image(int stage)
    //{
    //    int index = stage - 1;
    //    if (index < 0 || stageCount <= index || stageImageImageComponent == null) return;
    //    stageImageImageComponent.sprite = previewSprites[index];
    //}

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

