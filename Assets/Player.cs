using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public const float SPEED = 10f;
	private float dx = 0;
	private float dy = 0;
	private float rx = 0;
	private float ry = 0;
	private float r = 0;
	private LifeBar life;
	private GameObject body;
	private GameObject face;
	public GameObject LifePrefab;

	// On Editor
	public GameObject bulletPrefab = null;
	public GameObject bulletsField = null;

	void Awake() {
		var obj = Instantiate(LifePrefab) as GameObject;
		obj.transform.parent = this.transform;
		life = obj.AddComponent<LifeBar>();
		body = transform.FindChild("Body").gameObject;
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
	}
	
	// Update is called once per frame
	void Update () {
		face.transform.eulerAngles = new Vector3(0,0,Mathf.Sin(Time.fixedTime*10)*10);
		Move();
		RotateTarget();
	}

	void Move () {
		transform.Translate(new Vector3(dx*SPEED,dy*SPEED,0));
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
			body.transform.eulerAngles = new Vector3(0,0,-r*Mathf.Rad2Deg);
		}
		rx = 0;
		ry = 0;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Bullet") {
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


	private byte bulletFlag = 0;
	private void FireBullet()
	{
		unchecked{
			bulletFlag += 1;
		}
		if(bulletFlag % 8 != 0) return;
		var bulletObj = (GameObject)Instantiate( bulletPrefab, transform.position, transform.rotation );
		bulletObj.transform.parent = bulletsField.transform;
		var bullet = bulletObj.GetComponent<Bullet>();
		bullet.setForce( SPEED*2 * Mathf.Sin(r), SPEED*2 * Mathf.Cos(r), 0);
	}
}
