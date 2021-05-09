using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStation : MonoBehaviour
{
    WaterSupplyScript waterSupplyScript;

    public AudioClip PlayerRecoverSound;

    private AudioSource sound;

    private void Awake()
    {

        if(waterSupplyScript == null)
                waterSupplyScript = GetComponent<WaterSupplyScript>();

    }

    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerStatus>();
        if (player != null)
        {

            if(waterSupplyScript != null) 
            {

                if(waterSupplyScript.CrtWaterVal > 0)
                {
                    if (player.GetWaterRemaining <= player.GetWater_Strange) 
                    {

                        waterSupplyScript.BeingTakeWaterFunction();
                    player.StartHydration();
                    }
                    else 
                    {
                        waterSupplyScript.ReleaseTheTakingWaterFunction();
                        player.EndHydration();
                    }



                }
                else 
                if(waterSupplyScript.CrtWaterVal<=0)
                
                {

                    waterSupplyScript.ReleaseTheTakingWaterFunction();
                    player.EndHydration();

                }


            }
            else 
            {
                player.StartHydration();
            }

            if(AudioManager.instance != null) 
            {
                sound = AudioManager.instance.InstantiateAudioSound(PlayerRecoverSound);

                sound.loop = true;
                sound.volume = Random.Range(1.5f, 1.7f);
                sound.Play();
            }



     
        }
    }

    void OnTriggerStay(Collider other)
    {
        var player = other.GetComponent<PlayerStatus>();
      
        
        if(waterSupplyScript != null) 
        {





            if (waterSupplyScript.CrtWaterVal > 0) 
            {
                if (player.GetWaterRemaining<= player.GetWater_Strange)
                {
                    player.Hydration(100);
                    waterSupplyScript.BeingTakeWaterFunction();
                }
                else if(player.GetWaterRemaining>= player.GetWater_Strange) 
                {
                    player.EndHydration();
                    waterSupplyScript.ReleaseTheTakingWaterFunction();
                }





            }
                    else if (waterSupplyScript.CrtWaterVal <= 0) 
            {

                player.EndHydration();
                waterSupplyScript.ReleaseTheTakingWaterFunction();


            }

        }
        else 
        {

            if (player != null)
            {
                player.Hydration(100);
            }


        }
        
        
        
        
     
    }

    void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerStatus>();
              
        if(waterSupplyScript != null) 
        {
            if(player != null)
            player.EndHydration();

            waterSupplyScript.ReleaseTheTakingWaterFunction();
           
        }
        else 
        {


            if (player != null)
            {
                player.EndHydration();
            }
        }

        if (sound != null)
            Destroy(sound);
    }
}
