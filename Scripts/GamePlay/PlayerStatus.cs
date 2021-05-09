using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private const int WATER_STRAGE = 10000;
   
    public int GetWater_Strange 
    {
        get 
        {
            return WATER_STRAGE;
        }
    }

    UIManager uiManager;


    [SerializeField] private int WaterRemaining = WATER_STRAGE;

    public int GetWaterRemaining 
    {
        get 
        {
            return WaterRemaining;
        }
    }

    public bool doHydration = false;
    PlayerAnimatorScript animator;   // アニメーション


    private void Awake()
    {
        if(uiManager == null) 
        {
            uiManager = FindObjectOfType<UIManager>();
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        animator = transform.Find("Render/Prayer 2").GetComponent<PlayerAnimatorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WaterRemaining <= 0)
        {
            transform.Find("Splashing").GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }


        uiManager.SettingWaterLimitFunction
            ((float)WaterRemaining,(float)WATER_STRAGE);
    }

    public void Hydration(int amount)
    {
        if (amount > 0)
        {
            if (WaterRemaining + amount < WATER_STRAGE)
            {
                WaterRemaining += amount;
            }
            else
            {
                WaterRemaining = WATER_STRAGE;
            }
        }
        else
        {
            if (WaterRemaining > -amount)
            {
                WaterRemaining += amount;
            }
            else
            {
                WaterRemaining = 0;
            }
        }
    }

    public void StartHydration()
    {
        doHydration = true;
        animator.Charge_Set();
        // transform.Find("Splashing").GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void EndHydration()
    {
        doHydration = false;
        animator.Charge_End();
        // transform.Find("Splashing").GetComponent<ParticleSystem>().Play(true);

        GetComponent<Key2Shot>().startPressedTime = Time.time; // 不正は許しません
        GetComponent<Key2Shot>().pressedDuration = 0; // 不正は許しません
    }
}


// http://tsubakit1.hateblo.jp/entry/2017/12/16/154037