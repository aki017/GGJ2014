using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public const float SPEED = 10f;
	private float dx = 0;
	private float dy = 0;
	private float rx = 0;
	private float ry = 0;
	private float r = 0;

	// On Editor
	public GameObject bulletPrefab = null;
	public GameObject bulletsField = null;

	void Awake() {
	}

	// Use this for initialization
	void Start () {
		var i = (name == "1") ? XboxInput.i : KeyboardInput.i;
		i.RegistorUp(MoveUp);
		i.RegistorDown(MoveDown);
		i.RegistorLeft(MoveLeft);
		i.RegistorRight(MoveRight);	
		i.RegistorSubUp(RotateUp);
		i.RegistorSubDown(RotateDown);
		i.RegistorSubLeft(RotateLeft);
		i.RegistorSubRight(RotateRight);	
	}
	
	// Update is called once per frame
	void Update () {
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
		}
		rx = 0;
		ry = 0;
	}

	private void RotateUp(float v){ ry += v; }
	private void RotateDown(float v){ ry -= v; }
	private void RotateLeft(float v){ rx -= v; }
	private void RotateRight(float v){ rx += v; }

	private void MoveUp(float v){ dy += v; }
	private void MoveDown(float v){ dy -= v; }
	private void MoveLeft(float v){ dx -= v; }
	private void MoveRight(float v){ dx += v; }

	private void FireBullet()
	{
		var bulletObj = (GameObject)Instantiate( bulletPrefab, transform.position, transform.rotation );
		bulletObj.transform.parent = bulletsField.transform;
		var bullet = bulletObj.GetComponent<Bullet>();
		bullet.setForce( SPEED*2 * Mathf.Sin(r), SPEED*2 * Mathf.Cos(r), 0);
	}
}
