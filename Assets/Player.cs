using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public const float SPEED = 1.0f;
	private float dx = 0;
	private float dy = 0;
	private float rx = 0;
	private float ry = 0;
	private float r = 0;
	private LifeBar life;
	private GameObject body;
	private GameObject body_black;
	private GameObject body_white;
	private GameObject face;
	private Bullet.BulletType type = Bullet.BulletType.BLACK;

	void Awake() {
		life = transform.FindChild("LifeCircle").GetComponent<LifeBar>();
		body = transform.FindChild("Body").gameObject;
		body_black = body.transform.FindChild("BodyBlack").gameObject;
		body_white = body.transform.FindChild("BodyWhite").gameObject;
		face = transform.FindChild("Face").gameObject;
	}

	// Use this for initialization
	void Start () {
		var i = (name == "1") ? XboxInput.i : KeyboardInput.i;
		i.Registor(InputInterface.Type.UP,MoveUp);
		i.Registor(InputInterface.Type.DOWN,MoveDown);
		i.Registor(InputInterface.Type.LEFT,MoveLeft);
		i.Registor(InputInterface.Type.RIGHT,MoveRight);
		i.Registor(InputInterface.Type.SUBUP,RotateUp);
		i.Registor(InputInterface.Type.SUBDOWN,RotateDown);
		i.Registor(InputInterface.Type.SUBLEFT,RotateLeft);
		i.Registor(InputInterface.Type.SUBRIGHT,RotateRight);
		i.Registor(InputInterface.Type.CHANGE, ChangeType);
	}
	
	// Update is called once per frame
	void Update () {
		face.transform.eulerAngles = new Vector3(0,0,-rigidbody2D.velocity.x);
		AddForce();
		RotateTarget();
	}

	void AddForce () {
		rigidbody2D.AddForce(new Vector2(dx,dy)*100*SPEED);
		dx = 0;
		dy = 0;
	}

	void RotateTarget() {
		if (Mathf.Abs(rx) > 0.3 || Mathf.Abs(ry) > 0.3) {
			var target = Mathf.Atan2(rx, ry);
			var before = r;
			r = Mathf.LerpAngle(r * Mathf.Rad2Deg,target * Mathf.Rad2Deg, 0.2f) * Mathf.Deg2Rad;
			if(Mathf.Abs(before - r) > 0.5)r = target;

			FireBullet();
			transform.eulerAngles = new Vector3(0,0,-r*Mathf.Rad2Deg);
		}
		rx = 0;
		ry = 0;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Bullet") {
			other.gameObject.SendMessage("Hit", other.gameObject.GetComponent<Bullet>().type == type);
			HitBullet();
		}
	}
	private void HitBullet() {
		life.Life = life.Life - 1;
	}
	private void RotateUp(float v){ ry += v; }
	private void RotateDown(float v){ ry -= v; }
	private void RotateLeft(float v){ rx -= v; }
	private void RotateRight(float v){ rx += v; }

	private void MoveUp(float v){ dy += v; }
	private void MoveDown(float v){ dy -= v; }
	private void MoveLeft(float v){ dx -= v; }
	private void MoveRight(float v){ dx += v; }

	private void ChangeType(float v){
		type = type==Bullet.BulletType.BLACK ? Bullet.BulletType.WHITE : Bullet.BulletType.BLACK;
		var flag = type == Bullet.BulletType.BLACK;
		body_black.SetActive(flag);
		body_white.SetActive(!flag);
	}


	private byte bulletFlag = 0;
	private void FireBullet()
	{
		unchecked{
			bulletFlag += 1;
		}
		if(bulletFlag % 8 != 0) return;
		GameObjectPool pool = GameObjectPool.GetPool(type==Bullet.BulletType.BLACK ? "SadBullet" : "HappyBullet");
		var force = new Vector3(SPEED*1.5f * Mathf.Sin(r), SPEED*1.5f * Mathf.Cos(r), 0);
		GameObject instance = pool.GetInstance(transform.position + force * 5);
		instance.rigidbody2D.velocity = force*30;
		var bullet = instance.GetComponent<Bullet>();
		bullet.type = type;
	}
}
