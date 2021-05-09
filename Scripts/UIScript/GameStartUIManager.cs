using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameStartUIManager : MonoBehaviour
{

    public static GameStartUIManager instance 
    {
        private set;
        get;
    }

    public Button GameStartBtns;

    public AudioClip StartAudioClip;

    public GameObject LoadingImageGameObj;

    Animator loadingAnimator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }


        loadingAnimator = LoadingImageGameObj.GetComponent<Animator>();

    }

    private void Start()
    {
        GameStartBtns.onClick.AddListener(EnterSceneFunction);

        AudioManager.SoundInteger = 0;

    }

    void EnterSceneFunction() 
    {
        LoadingImageGameObj.SetActive(true);

       AudioManager.instance.PlaySoundFunction(StartAudioClip);


        if(loadingAnimator != null) 
        {
            loadingAnimator.SetBool("FadeInBoolean", true);
        }

        //Testing Using 
        SCENEMANAGERScript.instance.LoadingSceneFunction("βup");

    }


    public void DoMuteFunction() 
    {
        if(AudioManager.instance != null) 
        
        {
            AudioManager.instance.doMute = 
               ! AudioManager.instance.doMute;


        }



    }






}
