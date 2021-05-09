using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2Move : MonoBehaviour
{

	GameMaster gameMaster;

	Vector3 MOVEX = new Vector3(1f, 0, 0); // x軸方向に１マス移動するときの距離
	Vector3 MOVEZ = new Vector3(0, 0, 1f); // z軸方向に１マス移動するときの距離

	float step = 9f;     // 移動速度
	Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
	Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

	PlayerAnimatorScript animator;   // アニメーション

	private MapCreate map;


	public AudioClip[] WalkingAudioClip;

	float walkingSoundCrtTiming = 0.0f;
	float walkingSoundMaxTiming = 0.5f;

    private void Awake()
    {
        
		if(gameMaster== null) 
		{


			gameMaster = FindObjectOfType<GameMaster>();
		}


    }


    // Use this for initialization
    void Start()
	{
		target = transform.position;

		animator = transform.Find("Render/Prayer 2").GetComponent<PlayerAnimatorScript>();

		map = GameObject.Find("MapCriate").GetComponent<MapCreate>();  // map.isCollusion

		// animator.Anim_State(1);
	}

	// Update is called once per frame
	void Update()
	{

        if (!gameMaster.GetFlagGameOver)
		{

			// ① 移動中かどうかの判定。移動中でなければ入力を受付
			if (transform.position == target)
			{
				SetTargetPosition();

				if (map.isCollusion((int)target.x, (int)target.z))
				{
					transform.Find("Splashing").GetComponent<SplashDirection>().LookForward(target);
					target = prevPos;
				}
			}

			Move(); // たどり着くまでUpdateで繰り返し呼ばれる


			if (transform.position == target)
			{
				if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
				{
					animator.Move_End();
				}
			}



		}



	

	}

	// ② 入力に応じて移動後の位置を算出
	void SetTargetPosition()
	{

		prevPos = target;

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 lscale = animator.transform.localScale;

		int randAudio = Random.Range(0,WalkingAudioClip.Length);

		walkingSoundCrtTiming += Time.deltaTime;

		if (moveHorizontal > 0)
		{
			target = transform.position + MOVEX;
			// SetAnimationParam(1);
			animator.Move_Set();
			if (lscale.x > 0)
            {
				lscale.x *= -1;
				animator.transform.localScale = lscale;
			}

			//if(walkingSoundCrtTiming>= walkingSoundMaxTiming) 
			//{

			//	if (AudioManager.instance != null)
			//	{

			//		if (WalkingAudioClip != null)
			//			AudioManager.instance.InstantiateSoundAudioClipFunction(WalkingAudioClip[randAudio]);

			//	}



			//	walkingSoundCrtTiming = 0.0f;
			//	walkingSoundMaxTiming = Random.Range(0.25f, 0.45f);
			//}

		

			return;
		}
		if (moveHorizontal < 0)
		{
			target = transform.position - MOVEX;
			// SetAnimationParam(2);
			animator.Move_Set();
			if (lscale.x < 0)
			{
				lscale.x *= -1;
				animator.transform.localScale = lscale;
			}

			//if (walkingSoundCrtTiming >= walkingSoundMaxTiming)
			//{

			//	if (AudioManager.instance != null)
			//	{

			//		if (WalkingAudioClip != null)
			//			AudioManager.instance.InstantiateSoundAudioClipFunction(WalkingAudioClip[randAudio]);

			//	}



			//	walkingSoundCrtTiming = 0.0f;
			//	walkingSoundMaxTiming = Random.Range(0.25f, 0.45f);
			//}




			return;
		}
		if (moveVertical > 0)
		{
			target = transform.position + MOVEZ;
			// SetAnimationParam(3);
			animator.Move_Set();

			//if (walkingSoundCrtTiming >= walkingSoundMaxTiming)
			//{

			//	if (AudioManager.instance != null)
			//	{

			//		if (WalkingAudioClip != null)
			//			AudioManager.instance.InstantiateSoundAudioClipFunction(WalkingAudioClip[randAudio]);

			//	}



			//	walkingSoundCrtTiming = 0.0f;
			//	walkingSoundMaxTiming = Random.Range(0.3f, 0.7f);
			//}


			return;
		}
		if (moveVertical < 0)
		{
			target = transform.position - MOVEZ;
			// SetAnimationParam(0);
			animator.Move_Set();

			//if (walkingSoundCrtTiming >= walkingSoundMaxTiming)
			//{

			//	if (AudioManager.instance != null)
			//	{

			//		if (WalkingAudioClip != null)
			//			AudioManager.instance.InstantiateSoundAudioClipFunction(WalkingAudioClip[randAudio]);

			//	}



			//	walkingSoundCrtTiming = 0.0f;
			//	walkingSoundMaxTiming = Random.Range(0.25f, 0.45f);
			//}


			return;
		}


	}

	
	// ③ 目的地へ移動する
	void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
	}
}

// https://tama-lab.net/2017/09/%E3%80%90unity%E3%80%91vector3-movetowards%E3%82%92%E4%BD%BF%E3%81%A3%E3%81%A6%EF%BC%91%E3%83%9E%E3%82%B9%E3%81%9A%E3%81%A4%E7%A7%BB%E5%8B%95%E3%81%99%E3%82%8B%E6%96%B9%E6%B3%95/
// https://pikopiko.artm.jp/page/unity/33/