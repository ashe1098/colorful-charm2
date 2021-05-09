using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
    : MonoBehaviour
{
    public static int SoundInteger = 0;


    public static AudioManager instance 
    {
        private set;
        get;
    }

    AudioSource audioSources;

    public bool doMute = false;




    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        
        
        }
        else 
        {

            Destroy(this.gameObject);

        }

        audioSources = GetComponent<AudioSource>();


    }


    public void PlaySoundFunction(AudioClip clip,bool loop = false) 
    {

        if (!doMute) 
        {

            audioSources.Stop();

            audioSources.clip = clip;

            audioSources.Play();


            audioSources.loop = loop;





        }







    }

    public void InstantiateSoundAudioClipFunction
        (AudioClip clip,bool loop = false,bool destroy = true) 
    {

        GameObject instantiateSound = 
            new GameObject();

        instantiateSound.name = "Init Sound : "+SoundInteger.ToString();

        AudioSource audioSource =



        instantiateSound.AddComponent<AudioSource>();

        audioSource.Stop();

        audioSource.clip = clip;


        audioSource.Play();

        audioSource.volume = Random.Range(0.2f, 0.4f);

        audioSource.loop = loop;

        Destroy(instantiateSound, clip.length);


    }

    public AudioSource InstantiateAudioSound
    (AudioClip clip)
    {

        GameObject instantiateSound =
            new GameObject();

        AudioSource audioSource =



        instantiateSound.AddComponent<AudioSource>();

        audioSource.Stop();

        audioSource.clip = clip;

        return audioSource;
    }
}
