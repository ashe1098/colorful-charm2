using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSupplyScript : MonoBehaviour
{
    
    public enum WaterCrtState 
    {

        WaterInTheNormalState,
        WaterInTheBeingTakenState

    }

    public WaterCrtState waterCrtState;

    float increaseWaterVal = 50;
    float changeIncreaseWaterCrtVal = 0;
    float changeIncreaseWaterMaxVal = 3.0f;

    float decreaseWaterVal = 120;

    float changeDecreaseWaterCrtVal = 0.0f;
    
    float changeDecreaseWaterMaxVal = 2.0f;



    public float CrtWaterVal;

    public  float MaxWaterVal;




   
    WaterUIScript waterUIScript;

    
    Camera _cam;

    private void Awake()
    {

        _cam = Camera.main;

     
    }

    private void Start()
    {

        waterUIScript = GetComponentInChildren<WaterUIScript>();

        MaxWaterVal = Random.Range(9000, 12000);

        waterCrtState = WaterCrtState.WaterInTheNormalState;

               CrtWaterVal = MaxWaterVal;

        changeIncreaseWaterMaxVal = Random.Range(0.8f, 1.6f);

        changeDecreaseWaterMaxVal = Random.Range(1.1f, 1.4f);

        increaseWaterVal = 60;

        decreaseWaterVal = 150;

    }

    private void Update()
    {



        //Setting The Value Of the Crt Water 
        if (waterUIScript != null) 
        {

            waterUIScript.SettingCrtWaterSpriteFunction(CrtWaterVal,MaxWaterVal);
        }


     

        //Method : If Water Is In The Type which is Not Being Taken 
        //And  Less than Max 

        if(waterCrtState == WaterCrtState.WaterInTheNormalState) 
        {

            if (CrtWaterVal <= MaxWaterVal)

            {
                CrtWaterVal += Time.deltaTime * increaseWaterVal;

                changeIncreaseWaterCrtVal += Time.deltaTime;

                if(changeIncreaseWaterCrtVal >= 
                    changeIncreaseWaterMaxVal) 
                {
                    increaseWaterVal = Random.Range(60, 90);

                    changeIncreaseWaterCrtVal = 0.0f;

                    changeIncreaseWaterMaxVal = Random.Range(0.5f, 1.4f);

                }


                if(CrtWaterVal >= MaxWaterVal) 
                {

                    CrtWaterVal = MaxWaterVal;

                }

            }
            else if (CrtWaterVal <= 0)
            {

                CrtWaterVal = 0;

            }



        }




    }


    //Function : Being Take Water Function
    // Method : This is the Function that used 
    //For Being Taken The Water
    public void BeingTakeWaterFunction() 
    {
        if (CrtWaterVal > 0) 
        {
            CrtWaterVal -= Time.deltaTime *decreaseWaterVal ;

            waterCrtState = WaterCrtState.WaterInTheBeingTakenState;

            changeDecreaseWaterCrtVal += Time.deltaTime;

            if(changeDecreaseWaterCrtVal >= changeDecreaseWaterMaxVal) 
            {
                decreaseWaterVal = Random.Range(210, 250);

                changeDecreaseWaterCrtVal = 0.0f;

                changeDecreaseWaterMaxVal = Random.Range(0.8f, 1.4f);

            }


        }
        else if (CrtWaterVal <= 0) 
        {
            waterCrtState = WaterCrtState.WaterInTheNormalState;


        }

    }


    public void ReleaseTheTakingWaterFunction() 
    {

        waterCrtState = WaterCrtState.WaterInTheNormalState;



    }

}
