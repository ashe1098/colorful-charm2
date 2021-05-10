using UnityEngine;
using System.Collections;

public class Key2Move : MonoBehaviour
{
	// [SerializeField] private Vector3 moveSpeed = new Vector3(0.05f, 0.0f, 0.05f);
	public float speed = 10.0f;
	float moveX = 0f;
	float moveZ = 0f;

	CharacterController controller;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		moveX = Input.GetAxisRaw("Horizontal") * speed;  // 加速しないならGetAxisRaw
		moveZ = Input.GetAxisRaw("Vertical") * speed;
		Vector3 direction = new Vector3(moveX, 0, moveZ);

		controller.SimpleMove(direction);
	}
}

// http://unityleaning.blog.fc2.com/blog-entry-1.html
// http://portaltan.hatenablog.com/entry/2017/12/19/190358
// http://sasanon.hatenablog.jp/entry/2017/09/17/041612