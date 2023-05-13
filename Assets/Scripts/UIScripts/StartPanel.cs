using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartPanel : MonoBehaviour
{


    public GameObject buttonLeft;
    public GameObject buttonRight;
    public GameObject buttonExit;
    public TextMeshProUGUI stageText;

    public GameObject lvLeftButton;
    public GameObject lvRightButton;

    public GameObject stageImage;
    private Image stageImageImageComponent;
    public TextMeshProUGUI levelText;
    //public GameObject startPanel;

    private int currentStage;
    private int stageCount;
    private Sprite[] previewSprites;

    private int currentLevel;
    private int levelCount;

    //아예 씬 변환  선택 장면 -> 게임화면으로 
    // Start is called before the first frame update
    void Awake()
    {

        if (stageImage != null)
        {
            //이미지가 없다면 이미지 컴포턴트에서 가져온다 
            stageImageImageComponent = stageImage.GetComponent<Image>();
        }
        stageCount = 2;
        previewSprites = new Sprite[stageCount];
        currentStage = 1;

        levelCount = 2;
        currentLevel = 1;


    }


    public void lvLeftButton_clicked()
    {
        currentLevel += levelCount;
        currentLevel--;
        currentLevel %= levelCount;
        set_level_text(currentLevel);

        print("Lvleftlevel" + currentLevel);

    }


    public void lvRightButton_clicked()
    {
        currentLevel++;
        currentLevel %= levelCount;
        set_level_text(currentLevel);
        print("LvRightlevel" + currentLevel);
    }


    public void buttonLeft_clicked()
    {
        currentStage += stageCount;
        currentStage--;
        currentStage %= stageCount;
        change_stage(currentStage);


    }

    public void buttonRight_clicked()
    {
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

    private void set_level_text(int level)
    {
        int levelNum = level + 1;
        levelText.text = "level: " + levelNum.ToString();
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

    public void buttonExit_clicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }


}
