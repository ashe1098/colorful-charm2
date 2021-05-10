// https://gist.github.com/Buravo46/7728812

using UnityEngine;
using System.Collections;

public class Key2Move : MonoBehaviour
{
	// 速度
	[SerializeField] private Vector3 velocity;  // 移動方向
	// [SerializeField] private Vector3 moveSpeed = new Vector3(0.05f, 0.0f, 0.05f);
	[SerializeField] private float moveSpeed = 5.0f;  // 移動速度

	// Update is called once per frame
	void Update()
	{
		velocity = Vector3.zero;

		// 現在位置をPositionに代入
		Vector3 Position = transform.position;

        // 拡張性考えるなら　http://portaltan.hatenablog.com/entry/2017/12/19/190358　みたいな　Input.GetAxis("Horizontal")　で
		if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
			velocity.z += 1;
		if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
			velocity.x -= 1;
		if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
			velocity.z -= 1;
		if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
			velocity.x += 1;

		// 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
		velocity = velocity.normalized * moveSpeed * Time.deltaTime;

		// いずれかの方向に移動している場合
		if (velocity.magnitude > 0)
		{
			// プレイヤーの位置(transform.position)の更新
			// 移動方向ベクトル(velocity)を足し込みます
			transform.position += velocity;
		}
	}
}

// http://sasanon.hatenablog.jp/entry/2017/09/17/041612