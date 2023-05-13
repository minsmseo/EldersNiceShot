using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class MainPanelScript : MonoBehaviour
{
    public GameObject buttonLeft;
    public GameObject buttonRight;
    public GameObject buttonExit;
    public GameObject buttonClose;
    public TextMeshProUGUI stageText;
    public GameObject mainPanel;
    public GameObject scorePanel;
    public GameObject stageImage;
    private Image stageImageImageComponent;

    //public TextMeshProUGUI levelText;

    private int currentStage;
    private int stageCount;
    private Sprite[] previewSprites ;

    void Awake()
    {
        if(stageImage != null)
        {
            stageImageImageComponent = stageImage.GetComponent<Image>();
        }
        stageCount = 2;
        previewSprites = new Sprite[stageCount];
        currentStage = 1;
    }


    public void buttonLeft_clicked()
    {
        currentStage += stageCount;
        currentStage--;
        currentStage %= stageCount;
        change_stage(currentStage);
    }

    public void buttonRight_clicked() {
        currentStage++;
        currentStage %= stageCount;
        change_stage(currentStage);
    }

    public void stageImage_clicked()
    {
        
    }

    public void change_stage(int stage)
    {
        
        set_stage_image(stage);
        set_stage_text(stage);
    }

    private void set_stage_text(int stage)
    {
        int stageNum = stage + 1; 
        stageText.text = "stage: " + stageNum.ToString();
    }

    private void set_stage_image(int stage)
    {
        int index = stage - 1;
        if (index < 0 || stageCount <= index || stageImageImageComponent == null) return;
        stageImageImageComponent.sprite = previewSprites[index];
    }

    public void buttonClose_clicked()
    {
        mainPanel.SetActive(false);
        scorePanel.SetActive(true);
    }

    public void buttonExit_clicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

}
