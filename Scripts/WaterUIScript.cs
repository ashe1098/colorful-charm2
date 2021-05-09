using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



public class WaterUIScript : MonoBehaviour
{
   
    public Image CrtWaterSpriteImage;


    //Function : Setting Crt Water Sprite Function
    //Method : This is the Function that used 
    //For Setting Current Water Sprite 

    public void SettingCrtWaterSpriteFunction
        (float CrtAmount,
float MaxAmount) 
    {

        CrtWaterSpriteImage.fillAmount 
            = 
                    (CrtAmount/MaxAmount);


    }





}
