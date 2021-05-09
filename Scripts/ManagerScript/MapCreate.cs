using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    [SerializeField]
    [Tooltip("外壁")] GameObject Outer_Wall;
    [SerializeField]
    [Tooltip("内壁")] GameObject Inner_Wall;
    [SerializeField]
    [Tooltip("交差点")] GameObject Intersection_Rord;
    [SerializeReference]
    [Tooltip("横向き道路")] GameObject Side_Rord;
    [SerializeField]
    [Tooltip("縦向き道路")] GameObject Vertical_Rord;
    [SerializeField]
    [Tooltip("家")] GameObject _Hause;
    [SerializeField]
    [Tooltip("草")] GameObject _Grass;
    [SerializeField]
    [Tooltip("プレイヤーキャラ")] GameObject _Player;
    [SerializeField]
    [Tooltip("給水所")] GameObject Water_Supply;
    [SerializeField]
    [Tooltip("コーナー")] GameObject Corner_Rord;
    [SerializeField]
    [Tooltip("ノーマル")] GameObject Normal_Rord;
    [SerializeField]
    [Tooltip("T字路")] GameObject T_Rord;

    private Quaternion Hause_Dir;

    int[,] Map_Create = new int[19, 29]
    {
        //0 = スタート地点  //1 = 外壁  //2 = 内壁  //3 = 交差点  //4 = 縦向きの道路  //5 = 横向きの道路  
        //6 = 家  //7 = 草  //8 = 給水所  
        //9 = コーナー（↑→)  //10 = コーナー（↓→) //11 = コーナー（↑←)  //12 = コーナー（↓←）
        //13 = T字路（←向き)  //14 = T字路（↓向き)  //
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        {1,10, 5, 5,12, 2, 6, 6, 6, 6, 6, 6, 6, 6, 6, 2, 2, 2,10, 5, 5, 5, 5, 5, 5, 5, 5,12, 1 },
        {1, 4, 8, 2, 3, 5, 5,14, 5, 5, 5, 5, 5, 5,12, 7, 2, 7, 4, 2, 2, 2, 2, 6, 6, 6, 6, 4, 1 },
        {1, 4, 2, 6, 4, 6, 2, 4, 2, 6, 6, 6, 6, 2, 3, 5, 5, 5, 3, 5, 5, 5,12, 7, 2, 2, 2, 4, 1 },
        {1, 4, 2, 2, 4, 2, 7, 4, 2, 6, 6, 6, 6, 2, 4, 2, 2, 2, 4, 6, 6, 6, 4, 6, 6, 2, 8, 4, 1 },
        {1,16, 5, 5, 3, 6, 6,16, 5, 5, 5, 5, 5, 5,13, 6, 2, 6, 4, 6, 2, 6, 3, 5, 5, 5, 5,13, 1 },
        {1, 4, 6, 6, 4, 6, 6, 4, 2, 6, 6, 6, 6, 2, 4, 6, 2, 6, 4, 6, 6, 6, 4, 2, 6, 6, 2, 4, 1 },
        {1, 4, 6, 6, 4, 6, 6, 4, 6, 2, 2, 2, 2, 8, 4, 6, 2, 6, 9, 5, 5, 5,11, 6, 2, 2, 6, 4, 1 },
        {1, 4, 6, 6, 4, 6, 6, 4, 2, 6, 7, 6, 2,10, 3,12, 2, 2, 2, 6, 6, 6, 6, 2, 2, 2, 6, 4, 1 },
        {1, 4, 2, 2, 3, 5, 5,15, 5, 5, 5, 5, 5, 3, 0, 3, 5,12, 2, 2, 2, 2, 2, 6, 6, 6, 6, 4, 1 },
        {1, 4, 7, 6, 4, 2, 6, 6, 2, 6, 6, 6, 2, 9, 3,11, 2, 9, 5, 5, 5, 5, 5, 5, 5, 5, 5,13, 1 },
        {1, 4, 6, 6, 4, 2, 6, 6, 7, 2, 6, 6, 6, 2, 4, 2, 2, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 4, 1 },
        {1, 4, 6, 6, 9, 5, 5, 5, 5,14, 5, 5, 5, 5, 3, 5,12, 6, 6, 6, 6, 6, 6, 6, 6, 6, 2, 4, 1 },
        {1, 4, 6, 2, 6, 6, 6, 6, 2, 4, 2, 6, 2, 2, 4, 2, 9, 5, 5,14, 5, 5, 5,14, 5, 5, 5,13, 1 },
        {1, 4, 6, 2, 2, 2, 2, 2, 6, 4, 6, 2, 6, 6, 4, 6, 6, 6, 7, 4, 2, 6, 6, 2, 6, 6, 2, 4, 1 },
        {1, 4, 2, 2, 2, 2, 2, 2, 6, 4, 6, 2, 6, 6, 4, 6, 2, 2, 6, 4, 6, 2, 6, 2, 6, 2, 6, 4, 1 },
        {1, 4, 8, 2, 6, 6, 6, 6, 7, 4, 2, 6, 2, 2, 4, 2, 6, 6, 2, 4, 2, 6, 2, 8, 2, 7, 6, 4, 1 },
        {1, 9, 5, 5, 5, 5, 5, 5, 5,15, 5, 5, 5, 5,15, 5, 5, 5, 5,15, 5, 5, 5,15, 5, 5, 5,11, 1 },
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    };

    private GameMaster master;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        //壁や地面を生成
        InstantiateMapFunction();
    }

    void InstantiateMapFunction() 
    {
        for (int i = 0; i < Map_Create.GetLength(0); i++)
        {
            for (int j = 0; j < Map_Create.GetLength(1); j++)
            {
                //プレイヤーを生成
                if (Map_Create[i, j] == 0)
                {
                    Instantiate(_Player, new Vector3(i, 1.5f, j), Quaternion.identity);
                    Instantiate(Normal_Rord, new Vector3(i, 0, j), Quaternion.identity);
                }
                //外壁を生成
                if (Map_Create[i, j] == 1)
                    Instantiate(Outer_Wall, new Vector3(i, 1, j), Quaternion.identity);
                //内壁を生成
                if (Map_Create[i, j] == 2)
                    Instantiate(Inner_Wall, new Vector3(i, 0.65f, j), Quaternion.identity);
                //交差点を生成
                if (Map_Create[i, j] == 3)
                    Instantiate(Intersection_Rord, new Vector3(i, 0, j), Quaternion.identity);
                //横向き道路を生成
                if (Map_Create[i, j] == 4)
                    Instantiate(Side_Rord, new Vector3(i, 0, j), Quaternion.identity);
                //縦向き道路を生成
                if (Map_Create[i, j] == 5)
                    Instantiate(Vertical_Rord, new Vector3(i, 0, j), Quaternion.identity);
                //家を生成
                if (Map_Create[i, j] == 6)
                {
                    Instantiate(_Hause, new Vector3(i, 0.5f, j), Quaternion.Euler(-90, 0, 0));
                    master.NUM_BUILDINGS++;
                }
                //地面（草）を生成
                if (Map_Create[i, j] == 7 || Map_Create[i, j] == 6 || Map_Create[i, j] == 8)
                    Instantiate(_Grass, new Vector3(i, 0, j), Quaternion.identity);
                //給水を生成
                if (Map_Create[i, j] == 8)
                    Instantiate(Water_Supply, new Vector3(i, 1, j), Quaternion.identity);
                //コーナー（↑→）を生成
                if (Map_Create[i, j] == 9)
                    Instantiate(Corner_Rord, new Vector3(i, 0, j), Quaternion.identity);
                //コーナー（↓→）を生成
                if (Map_Create[i, j] == 10)
                    Instantiate(Corner_Rord, new Vector3(i, 0, j), Quaternion.Euler(0, 90, 0));
                //コーナー（↑←）を生成
                if (Map_Create[i, j] == 11)
                    Instantiate(Corner_Rord, new Vector3(i, 0, j), Quaternion.Euler(0, -90, 0));
                //コーナー（↓←）を生成
                if (Map_Create[i, j] == 12)
                    Instantiate(Corner_Rord, new Vector3(i, 0, j), Quaternion.Euler(0, 180, 0));
                //T字路を生成（右向き）
                if (Map_Create[i, j] == 13)
                    Instantiate(T_Rord, new Vector3(i, 0, j), Quaternion.identity);
                //T字路を生成（下向き）
                if (Map_Create[i, j] == 14)
                    Instantiate(T_Rord, new Vector3(i, 0, j), Quaternion.Euler(0, -90, 0));
                //T字路を生成（上向き）
                if (Map_Create[i, j] == 15)
                    Instantiate(T_Rord, new Vector3(i, 0, j), Quaternion.Euler(0, 90, 0));
                //T字路を生成（左向き）
                if (Map_Create[i, j] == 16)
                    Instantiate(T_Rord, new Vector3(i, 0, j), Quaternion.Euler(0, 180, 0));
            }
        }



    }




    // Update is called once per frame
    void Update()
    {

    }

    public bool isCollusion(int x, int z)
    {
        // Debug.Log(Map_Create[x, z]);
        switch(Map_Create[x, z])
        {
            case 1: case 2: case 6:
                return true;
            default:
                return false;
        }
    }
}
