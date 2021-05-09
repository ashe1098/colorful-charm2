using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDirection : MonoBehaviour
{
    

    private Vector3 latestPos;  //前回のPosition
    // Update is called once per frame
    private void Update()
    {
        LookForward(transform.parent.position);
        latestPos = transform.parent.position; //前回のPositionの更新
    }

    public void LookForward(Vector3 target)
    {
        Vector3 diff = target - latestPos;   //前回からどこに進んだかをベクトルで取得

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }
    }
}

// https://www.hanachiru-blog.com/entry/2019/02/20/183552

// パーティクル
// http://marupeke296.com/UNI_PT_No1_Shuriken.html
// https://gametukurikata.com/effect/particlecollision