using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningStatus : MonoBehaviour
{
    UIManager uiManager;
    private GameMaster master;
    public const int DONE_BONUS = 1000;
    public float timeBonus;  // key2shotから更新

    // 体力値を格納する変数
    public const int maxHealth = 10000;
    // 現在の体力値を格納する変数
    public int currentHealth;

    public const int NO_FIRE = -100;
    private float repairDuration;
    private float fireRepairTime;
    private int nowActive;

    private const float LIMIT_COOLTIME = 30.0f;
    private float coolTime;

    public GameObject houseUIPosition;

    
    HouseUIHealthImageScript houseUIHealthImage;


    public AudioClip fireAudioSound;



    float fireCrtTiming = 0.0f;

    float maxFireTiming = 3.0f;


    void Awake()
    {
        timeBonus = 0;

        currentHealth = NO_FIRE;
        float repairDuration = 5.0f;

        fireRepairTime = Time.time + repairDuration;

        GameObject findMasterGameObj = GameObject.Find("GameMaster");
       
        if(findMasterGameObj != null) 
        {

            master = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        }

        coolTime = LIMIT_COOLTIME;


        uiManager = FindObjectOfType<UIManager>();

        houseUIHealthImage = GetComponentInChildren<HouseUIHealthImageScript>();

    }

    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            nowActive = -1;
        }

        houseUIPosition.SetActive(true);

       


        checkBurning();
    }

    void Update()
    {

        houseUIHealthImage.SettingCrtHealthFunction(currentHealth,maxHealth);


        if (currentHealth != NO_FIRE && currentHealth < maxHealth)
        {
            if (Time.time >= fireRepairTime)
            {
                currentHealth += 5;
                checkBurning();
            }
        }

        if(nowActive != -1)  // 現在の火災状況に合わせて家にダメージを与える
        {
            switch(nowActive)
            {
                case 1: causeDamageHouse(1); break;
                case 2: causeDamageHouse(10); break;
                case 3: causeDamageHouse(40); break;
            }
        } else if (GetComponent<HouseStatus>().currentHealth > 0)
        {
            float random = Random.value;
            if(random < 0.0001)
            {
                Ignition((int)(random * 1000000));
            }
        }
    }

    // ダメージ処理
    public void TakeDamage(int amount)
    {
        fireRepairTime = Time.time + repairDuration;

        if (currentHealth != NO_FIRE)
        {
            //fireCrtTiming += Time.deltaTime;

            //if(fireCrtTiming >= maxFireTiming) 
            //{
            //    fireCrtTiming = 0.0f;

            //    if(AudioManager.instance != null) 
            //    {
            //        if(fireAudioSound)
            //        AudioManager.instance.InstantiateSoundAudioClipFunction
            //            (fireAudioSound);
            //    }


            //    maxFireTiming = Random.Range(4.0f, 12.0f);


            //}




            // 現在の体力値から 引数 amount の値を引く
            currentHealth -= amount;
            addContinueScore(amount);
            // 現在の体力値が 0 以下の場合
            if (currentHealth <= 0)
            {


                // 現在の体力値に 0 を代入
                currentHealth = NO_FIRE;
                //GameObject burning = transform.Find("Burning").gameObject;
                //Destroy(burning);
                if(houseUIPosition)
                        Destroy(houseUIPosition);


                if(master != null) 
                {
  master.addScore(DONE_BONUS);
                }

              
            }

        }
        checkBurning();
    }

    // https://qiita.com/Armyporoco/items/391776d4c79d25cfbbfe
    // 状態を切り替える
    public void checkBurning()
    {
        if (currentHealth == NO_FIRE)
        {
            if(nowActive != -1)
            {
                transform.GetChild(nowActive).gameObject.SetActive(false);
                nowActive = -1;
            }
        }
        else if (currentHealth < maxHealth * 0.3)
        {
            if (nowActive != 0)
            {
                if (nowActive != -1)
                {
                    transform.GetChild(nowActive).gameObject.SetActive(false);
                }
                nowActive = 0;
                transform.GetChild(nowActive).gameObject.SetActive(true);
            }
        } 
        else if (currentHealth < maxHealth * 0.7)
        {
            if (nowActive != 1)
            {
                if (nowActive != -1)
      {
                    transform.GetChild(nowActive          ).gameObject.SetActive(false);
                }
                nowActive = 1;
                transform.GetChild(nowActive).gameObject.SetActive(true);
            }
        }
        else if (currentHealth <= maxHealth)
        {
            if (nowActive != 2)
            {
                if (nowActive != -1)
                {
                    transform.GetChild(nowActive).gameObject.SetActive(false);
                }
                nowActive = 2;
                transform.GetChild(nowActive).gameObject.SetActive(true);
            }
        }
    }

    void causeDamageHouse(int amount)
    {
        var target = GetComponent<HouseStatus>();

        target.takeDamage(amount);
        if(target.currentHealth == 0)  // 家が無くなったら鎮火
        {
            currentHealth = NO_FIRE;
            checkBurning();
        }
    }

    void Ignition(int health)
    {
        if(currentHealth == NO_FIRE)
        {
            currentHealth = health;
            checkBurning();
        }
    }

    void addContinueScore(int amount)
    {
        int res = amount * (int)(timeBonus * 10);

        if(master != null)
                master.addScore(res);

        // 取得点数の描写とかしたい
    }
}

// https://gametukurikata.com/effect/particlecollision
// http://corevale.com/unity/5604