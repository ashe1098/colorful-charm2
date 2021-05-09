using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///アニメーションを制御するスクリプトです。
///各アニメーションの切り替えはメソッドで行えるので、
///任意のタイミングで再生、停止させることができますよ。
///</summary>
public class PlayerAnimatorScript : MonoBehaviour
{
    private Animator anim;
    //表情差分、Set activeを切り替えることで表示を切り替える。
    [Header("目　デフォルト")] [SerializeField] public GameObject Eye_1;
    [Header("目　にっこり")] [SerializeField] public GameObject Eye_2;
    [Header("目　あせり")] [SerializeField] public GameObject Eye_3;
    [Header("目　おこ")] [SerializeField] public GameObject Eye_4;
    [Header("口　デフォルト")] [SerializeField] public GameObject Mouth_1;
    [Header("口　あんぐり")] [SerializeField] public GameObject Mouth_2;
    [Header("おこまゆ")] [SerializeField] public GameObject Mayu;

    //表示する表情差分の組み合わせを定義します。
    private int State = 0;

    private float time_limit = 1f;
    private float time = 0f;
    private bool mabataki = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        FlagReset();
    }

     void Update()
    {
        /*
        if(State==0)
        {
            if(mabataki==false)
            {
                Invoke(nameof(Mabataki_Set),5);
                //Invoke(nameof(Mabataki_Set), time_limit);
                Debug.Log("ん？");
            }
            else
            {
                //Invoke(nameof(Mabataki_End), time_limit);
                Invoke(nameof(Mabataki_End), 1);
                Debug.Log("e？");
            }
        }*/
    }

    ///<summary>
    /// Stateの内容によって状態を変更。
    /// 0＝デフォルト　1＝あせり　2＝おこ
    ///</summary>
    public void Anim_State(int GetState)
    {
        if (GetState == 0)
        {
            Debug.Log("デフォルティーナ");
            //表示
            Eye_1.SetActive(true);
            Mouth_1.SetActive(true);
            //非表示
            Eye_2.SetActive(false);
            Eye_3.SetActive(false);
            Eye_4.SetActive(false);
            Mouth_2.SetActive(false);
            Mayu.SetActive(false);

        }
        else if (GetState == 1)
        {
            Debug.Log("あせってるよ！");
            //表示
            Eye_3.SetActive(true);
            Mouth_2.SetActive(true);
            //非表示
            Eye_1.SetActive(false);
            Eye_2.SetActive(false);
            Eye_4.SetActive(false);
            Mouth_1.SetActive(false);
            Mayu.SetActive(false);
        }
        else
        {
            Debug.Log("おこだよ！！");
            //表示
            Eye_4.SetActive(true);
            Mouth_2.SetActive(true);
            Mayu.SetActive(true);
            //非表示
            Eye_1.SetActive(false);
            Eye_2.SetActive(false);
            Eye_3.SetActive(false);
            Mouth_1.SetActive(false);
        }
        State = GetState;
    }


    ///<summary>
    ///移動アニメーションを再生するよ。
    ///</summary>
    public void Move_Set()
    {
        anim.SetBool("Move", true);
    }
    ///<summary>
    ///移動アニメーションを停止させるよ。
    ///</summary>
    public void Move_End()
    
    {

        if(anim != null)

        anim.SetBool("Move", false);
    }

    ///<summary>
    ///水を解き放つッ！！！
    ///</summary>
    public void Magic_Set()
    {
        anim.SetBool("Magic", true);
    }

    ///<summary>
    ///お仕事おわり！！
    ///</summary>
    public void Magic_End()
    {
        anim.SetBool("Magic", false);
    }

    ///<summary>
    ///給水ッ！！！！！
    ///</summary>
    public void Charge_Set()
    {
        anim.SetBool("Charge", true);
    }

    ///<summary>
    ///余の心は満たされた・・・
    ///</summary>
    public void Charge_End()
    {
        anim.SetBool("Charge", false);
    }

    //フラグ初期化
    void FlagReset()
    {
        anim.SetBool("Move", false);
        anim.SetBool("Magic", false);
        anim.SetBool("Charge", false);
    }

    //まばたき
    void Mabataki_Set()
    {
        Eye_2.SetActive(true);
        Eye_1.SetActive(false);
        Eye_3.SetActive(false);
        Eye_4.SetActive(false);
        mabataki = true;
        //time_limit = Random.Range(1.0f, 3.0f);
    }
    void Mabataki_End()
    {
        Eye_1.SetActive(true);
        Eye_2.SetActive(false);
        mabataki = false;
        //time_limit = Random.Range(6.0f, 15.0f);
    }
}