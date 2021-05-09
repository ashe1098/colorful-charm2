using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class SCENEMANAGERScript : MonoBehaviour
{
    public static SCENEMANAGERScript instance 
    {
        private set;

        get;
    }



    private void Awake()
    {
        
        if(instance == null) 
        {

            instance = this;
        
        }


    }

    public void LoadingSceneFunction(string name) 
    {


        StartCoroutine(LoadingSceneIEnumerator(name));

    }


    IEnumerator LoadingSceneIEnumerator(string name) 
    {

        yield return new WaitForSeconds(2.5f);

        AsyncOperation async = SceneManager.LoadSceneAsync(name);




        while (!async.isDone) 
        {
            yield return null;
        }




    }





}
