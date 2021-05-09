using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    GameMaster gameMaster;

    public Text LimitTimeText;

    public Text ScoreText;


    public Image WaterLimitImage;

    public Transform HousesLimitTransformSetting;


    public GameObject GameOverPanelObjs;

    public GameObject LoadingImageObj;


    private void Awake()
    {
        if (gameMaster == null)
            gameMaster = FindObjectOfType<GameMaster>();


    }



    public void SettingTimeLimitFunction(int timing) 
    {

        LimitTimeText.text =    timing.ToString();
    }

    public void SettingScoreTextFunction(int score ) 
    {
        ScoreText.text = score.ToString();


    }

    public void SettingWaterLimitFunction
        (float minAmount , float maxAmount) 
    {

        WaterLimitImage.fillAmount = minAmount / maxAmount;
    }
    


  


}
