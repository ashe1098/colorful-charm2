using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



public class AudioUISettingScript : MonoBehaviour
{
   
    public AudioMixer audioMixer;
    AudioSource audioSource;

    public GameObject AudioObjPanelObj;

    public UnityEngine.UI.Slider sliderVal;

    private void Awake()
    {
        if(audioSource == null) 
        {

            audioSource = GetComponent<AudioSource>();

        }


    }

    public void SetSoundFunction() 
    {


        audioSource.volume = sliderVal.value;
       // audioSource.Play();
      
    }

    public void OpenAudioSourceFunction() 
    {

        AudioObjPanelObj.SetActive(true);



    }

    public void CloseAudioSourceFunction() 
    {

        AudioObjPanelObj.SetActive(false);
    }


}
