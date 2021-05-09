using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseInit : MonoBehaviour
{
    private GameMaster master;

    public GameObject houseObjPrefab;
    public GameObject housesObj;

    void Awake()
    {
        master = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        int n = 3;
        for (int i = 0; i < n; i++)
        {
            GameObject g = Instantiate(houseObjPrefab, housesObj.transform);
            g.transform.position = new Vector3((0.0f + (5.0f * i)), 1.5f, 8.0f);
        }

        master.NUM_BUILDINGS = n;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}