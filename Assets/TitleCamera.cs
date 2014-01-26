using UnityEngine;
using System.Collections;

public class TitleCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0,0, -60 - 1 * Mathf.Sin (1.0f*Time.frameCount/ 6));
		if(Input.anyKey){
			Application.LoadLevel("Tutorial");
		}
	
	}
}
