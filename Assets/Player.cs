using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public const float SPEED = 10f;
	private float dx;
	private float dy;

	// Use this for initialization
	void Start () {
		var i = (name == "1") ? XboxInput.i : KeyboardInput.i;
		i.RegistorUp(MoveUp);
		i.RegistorDown(MoveDown);
		i.RegistorLeft(MoveLeft);
		i.RegistorRight(MoveRight);	
	}
	
	// Update is called once per frame
	void Update () {
		Move();
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
}
