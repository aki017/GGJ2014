using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public const float SPEED = 10f;
	private float dx;
	private float dy;
	private bool trans;
	
	public GameObject bulletPrefab = null;
	private float bulletInterval = 0.2f;
	private bool bulletEnable = true;
	private float bulletVelocity = 100f;
	private float bulletTime = 0.0f;


	// Use this for initialization
	void Start () {
		var i = (name == "1") ? XboxInput.i : KeyboardInput.i;
		i.RegistorUp(MoveUp);
		i.RegistorDown(MoveDown);
		i.RegistorLeft(MoveLeft);
		i.RegistorRight(MoveRight);	
		i.RegistorBullet(MoveBullet);
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		bulletTime += Time.deltaTime;
		if( bulletTime > bulletInterval )
		{
			bulletTime = 0.0f;
			bulletEnable = true;
		}
	}

	void Move () {
		transform.Translate(new Vector3(dx*SPEED,dy*SPEED,0));
		dx = 0;
		dy = 0;
	}

	private void MoveUp(float v){ dy += v; }
	private void MoveDown(float v){ dy -= v; }
	private void MoveLeft(float v){ dx -= v; }
	private void MoveRight(float v){ dx += v; }

	private void MoveBullet(float v)
	{
		if(bulletEnable)
		{
			bulletEnable = false;
			var bulletObj = (GameObject)Instantiate( bulletPrefab, transform.position, transform.rotation );
			var bullet = bulletObj.GetComponent<Bullet>();
			bullet.setForce( dx*2, dy*2, 0);
		}
	}
}
