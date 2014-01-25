using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private float dx;
	private float dy;

	// Use this for initialization
	void Start () {
		var i = KeyboardInput.i;
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
		transform.Translate(new Vector3(dx*10,dy*10,0));
		dx = 0;
		dy = 0;
	}

	private void MoveUp(){ dy += 1.0f; }
	private void MoveDown(){ dy -= 1.0f; }
	private void MoveLeft(){ dx -= 1.0f; }
	private void MoveRight(){ dx += 1.0f; }
}
