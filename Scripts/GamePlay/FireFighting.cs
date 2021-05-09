using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFighting : MonoBehaviour
{
    




    // コリジョンと衝突した場合の処理
    void OnParticleCollision(GameObject hit)
    {
        var burning = hit.GetComponent<BurningStatus>();
        if (burning != null)
        {
            // ダメージ処理を実行
            burning.timeBonus = transform.parent.GetComponent<Key2Shot>().pressedDuration;
            burning.TakeDamage(100);
        }
    }
}

// https://gametukurikata.com/effect/particlecollision
// http://corevale.com/unity/5604