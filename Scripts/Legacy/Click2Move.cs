// https://www.ame-name.com/archives/293

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click2Move : MonoBehaviour
{

    public Text text;
    Vector3 cursorPosition;
    Vector3 cursorPosition3d;
    RaycastHit hit;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 Position = transform.position;
        cursorPosition = Input.mousePosition; // 画面上のカーソルの位置
        cursorPosition.z = 10.0f; // z座標に適当な値を入れる
        cursorPosition3d = Camera.main.ScreenToWorldPoint(cursorPosition); // 3Dの座標になおす

        // カメラから cursorPosition3d の方向へレイを飛ばす
        if (Physics.Raycast(Camera.main.transform.position, (cursorPosition3d - Camera.main.transform.position), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(Camera.main.transform.position, (cursorPosition3d - Camera.main.transform.position) * hit.distance, Color.red);

            text.text = hit.point.ToString();
        }

        target.transform.position = new Vector3(hit.point.x, 2.0f, hit.point.z);

    }
}