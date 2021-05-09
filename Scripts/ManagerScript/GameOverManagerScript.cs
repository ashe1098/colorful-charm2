using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameOverManagerScript : MonoBehaviour
{

    const int SRankScore = 5000000;

    const int ARankScore = 2000000;

    const int BRankScore =500000;



    public Text SCORERANKText;

    public Color GoldenColor;
    public Color RedColor;

    public Color NormalColor;

    public Color WorstColor;


    public Text ScoreNumberText;

    public GameObject LoadingImageObj;

    public AudioClip GameOverSoundAudioClip;

    public AudioClip DesicionSoundAudioClip;

    public GameObject poses;



    private void Start()
    {
        if (AudioManager.instance != null) 
        {


            AudioManager.instance.PlaySoundFunction(GameOverSoundAudioClip,true);


        }

        GameObject PoseS = poses.transform.GetChild(0).gameObject;
        GameObject PoseA = poses.transform.GetChild(3).gameObject;
        GameObject PoseB = poses.transform.GetChild(2).gameObject;
        GameObject PoseC = poses.transform.GetChild(1).gameObject;

        PoseS.SetActive(false);
        PoseA.SetActive(false);
        PoseB.SetActive(false);
        PoseC.SetActive(false);

        ScoreNumberText.text = SCOREUpdate.SCOREInteger.ToString();

        if (SCOREUpdate.SCOREInteger >= SRankScore) 
        {
            SCORERANKText.color = GoldenColor;
            SCORERANKText.text = "S";

            PoseS.SetActive(true);
        }
        else if(SCOREUpdate.SCOREInteger >= ARankScore) 
        {
            SCORERANKText.color = RedColor;
            SCORERANKText.text = "A";

            PoseA.SetActive(true);
        }
        else if (SCOREUpdate.SCOREInteger >= BRankScore)
        {
            SCORERANKText.color = NormalColor;
            SCORERANKText.text = "B";

            PoseB.SetActive(true);
        }
        else 
        {
            SCORERANKText.text = "C";
            SCORERANKText.color = WorstColor;

            PoseC.SetActive(true);
        }

    }



    public void GotoGameMainFunction() 
    {
        if(AudioManager.instance != null) 
        {


            AudioManager.instance.PlaySoundFunction(DesicionSoundAudioClip);

        }

        
        LoadingImageObj.SetActive(true);
        SCENEMANAGERScript.instance.LoadingSceneFunction("βup");

    }

}
