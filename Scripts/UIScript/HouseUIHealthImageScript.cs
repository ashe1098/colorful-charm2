using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseUIHealthImageScript : MonoBehaviour
{
    Vector3 pos;

    public void SettingUISettingFunction
        (Vector3 pos) 
    
    {
        this.pos
          = pos;



    }



    public Image CrtHealthBar;

  
   


    public void SettingCrtHealthFunction
        (float Crt,float Max) 
    {
        if(CrtHealthBar != null)
            CrtHealthBar.fillAmount = Crt / Max;


    }


  





}
