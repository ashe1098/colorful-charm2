using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCOREUpdate 
{
    public static int SCOREInteger ;


}




public class GameMaster : MonoBehaviour
{
    public const float TIME_LIMIT = 180.0f;
    public float startTime;
    [SerializeField] private float nowTime;
  


    [SerializeField] private int score;
   

    public int NUM_BUILDINGS;
    private int collapsed;
    [SerializeField] private float collapseRate;
    private const float COLLAPSE_LIMIT = 0.99f;  // パーセント
    private bool flgGameover;

    public bool GetFlagGameOver 
    {
        get 
        {
            return flgGameover;
        }
    }

    UIManager uiManager;

    bool HasLoadingGameOverScene = false;

    public AudioClip GameMainAudioClip;


    void Awake()
    {
        score = 0;

        
        startTime = Time.time;
        nowTime = startTime;
        collapsed = 0;
        collapseRate = collapseRate / NUM_BUILDINGS;
        flgGameover = false;

        uiManager = FindObjectOfType<UIManager>();
    }
    private void Start()
    {
        if(AudioManager.instance != null) 
        {

            AudioManager.instance.PlaySoundFunction(GameMainAudioClip,true);


        }

        HasLoadingGameOverScene = false;

    }





    void Update()
    {
        nowTime = Time.time;
        float remainingTime = TIME_LIMIT - (nowTime - startTime);
        if (remainingTime < 0)
        {
            flgGameover = true;
            // Debug.Log("タイムアップ");
        } 

        if(uiManager != null) 
        {
            if (remainingTime > 0) 
            {
                uiManager.SettingTimeLimitFunction((int)System.Math.Ceiling(remainingTime));
            }


         

            uiManager.SettingScoreTextFunction(score);
        
        
        }
        


        if (flgGameover)
        {
            // Debug.Log("ゲームオーバー");
            uiManager.LoadingImageObj.SetActive(true);

            StartCoroutine(LoadingToGameOverSceneIEnumerator());


        }
    }


    IEnumerator LoadingToGameOverSceneIEnumerator() 
    {

        if (HasLoadingGameOverScene) yield break;

        HasLoadingGameOverScene = true;


        SCOREUpdate.SCOREInteger = score;
        
        yield return new WaitForSeconds(0.3f);

       
        SCENEMANAGERScript.instance.LoadingSceneFunction
            ("GameOverScene");


    }



    public void addScore(int amount)
    {
        if(!flgGameover)
        {
            if(score + amount >= 0)  // 一応マイナスにはならないように
            {
                score += amount;
            } else if (amount < 0)
            {
                score = 0;
            }

          
       
            // Debug.Log(amount);
        }
    }

    public void doneCollapse()
    {
        addScore(-1000);

        collapsed++;
        collapseRate = (float)collapsed / NUM_BUILDINGS;

        if (collapseRate > COLLAPSE_LIMIT)
        {
            flgGameover = true;
        }

    }
}
