using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseStatus : MonoBehaviour
{
    public const int maxHealth = 10000;
    public int currentHealth = maxHealth;

   
    public void takeDamage(int amount)
    {
        if(amount > 0)
        {
            currentHealth -= amount;
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            DoneCollapse();
        }
    }

    void DoneCollapse()
    {
        var master = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        master.doneCollapse();

        // マテリアルを管理してるコンポーネントの取得
        Renderer renderer = GetComponent<Renderer>();
        // マテリアルの色を黒に変更する
        renderer.material.color = Color.black;
    }
}
