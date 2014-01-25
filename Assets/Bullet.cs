using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	private float dx = 0;
	private float dy = 0;
	private Vector3 dv;

	public void setForce(float x,float y,float z) {
		dx = x;
		dy = y;
		dv = new Vector3(dx,dy,0);
	}
	// Use this for initialization
	void Start () {
		dv = new Vector3(dx,dy, 0);
		transform.Translate(dv*4);

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(dv);
	}
}
