using UnityEngine;
using System.Collections;

public class Key2Shot : MonoBehaviour
{

    GameMaster gameMaster;
    public float pressedDuration;
    public float startPressedTime;

    Transform splasher;
    ParticleSystem bullet;
    PlayerStatus player;

    PlayerAnimatorScript animator;   // アニメーション


    public AudioClip ShootSoundAudioClip;

    private void Awake()
    {
        gameMaster = FindObjectOfType<GameMaster>();

    }


    void Start()
    {
        pressedDuration = 0;
        startPressedTime = 0;

        splasher = transform.Find("Splashing");
        bullet = splasher.GetComponent<ParticleSystem>();
        player = GetComponent<PlayerStatus>();

        bullet.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        animator = transform.Find("Render/Prayer 2").GetComponent<PlayerAnimatorScript>();
    }

    private AudioSource sound;

    void Update()
    {
        if (!gameMaster.GetFlagGameOver)
        {
            if (Input.GetButtonDown("Jump") && !GetComponent<PlayerStatus>().doHydration)
            {
                animator.Magic_Set();
                if (player.GetWaterRemaining != 0)
                {
                    startPressedTime = Time.time;
                    bullet.Play(true);


                    if (AudioManager.instance != null)
                    {
                        if (ShootSoundAudioClip != null)
                            sound = AudioManager.instance.InstantiateAudioSound(ShootSoundAudioClip);

                        sound.loop = true;
                        sound.volume = Random.Range(1.5f, 1.7f);
                        sound.Play();
                    }



                }
            }
            else if (Input.GetButtonUp("Jump") || GetComponent<PlayerStatus>().doHydration)  // スペース押したまま給水所に入る輩を許さない
            {
                startPressedTime = Time.time;
                pressedDuration = 0;
                bullet.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                animator.Magic_End();

                if (sound != null)
                    Destroy(sound, ShootSoundAudioClip.length);

            }
            else if (Input.GetButton("Jump") && !GetComponent<PlayerStatus>().doHydration)
            {
                pressedDuration = Time.time - startPressedTime;
                player.Hydration(-10);
            }
        



    }
        else 
        {
            startPressedTime = Time.time;
            pressedDuration = 0;
            bullet.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            animator.Magic_End();

            if (sound != null)
                Destroy(sound, ShootSoundAudioClip.length);



        }

    }
}