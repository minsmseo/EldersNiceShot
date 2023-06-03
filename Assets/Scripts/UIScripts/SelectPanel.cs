using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectPanel : MonoBehaviour
{


    public GameObject buttonLeft;
    public GameObject buttonRight;
    public GameObject buttonBack;
    public TextMeshProUGUI stageText;

    public GameObject selectPanel;
    public GameObject chooseLVPanel;


    public GameObject stageImage;
    private Image stageImageImageComponent;
   
    //public GameObject startPanel;

    private int currentStage;
    private int stageCount;
    private Sprite[] previewSprites;

   
    // Start is called before the first frame update
    void Awake()
    {

        //if (stageImage != null)
        //{
        //    //이미지가 없다면 이미지 컴포턴트에서 가져온다 
        //    stageImageImageComponent = stageImage.GetComponent<Image>();
        //}
        stageCount = 2;
        //previewSprites = new Sprite[stageCount];
        currentStage = 1;

        stageText.text = "stage: " + currentStage.ToString();

        buttonLeft.GetComponent<Button>().onClick.AddListener(buttonLeft_clicked);
        buttonRight.GetComponent<Button>().onClick.AddListener(buttonRight_clicked);
        buttonBack.GetComponent<Button>().onClick.AddListener(buttonBack_clicked);
        stageImage.GetComponent<Button>().onClick.AddListener(moveToGame);
        
        
    }


    public void moveToGame()
    {
        StartCoroutine(LoadingScene());
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
    }

    IEnumerator LoadingScene()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync("Stage_1");
        
        while (!loading.isDone) //씬 로딩 완료시 로딩완료시 완료
        {
            
            yield return null;
        }
    }



    public void buttonBack_clicked()
    {
        chooseLVPanel.SetActive(true);
        selectPanel.SetActive(false);
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
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

        //set_stage_image(stage);
        set_stage_text(stage);
        SoundManager.Instance.PlayEffectSound(eSFX.eUI_Button);
    }

    private void set_stage_text(int stage)
    {
        int stageNum = stage + 1;
        stageText.text = "stage: " + stageNum.ToString();
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
