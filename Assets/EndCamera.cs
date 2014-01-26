using UnityEngine;
using System.Collections;

public class EndCamera : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)) {
			Application.LoadLevel("Main");
		}else if(Input.GetKey(KeyCode.Space)){
			Application.LoadLevel("Title");
		}
	
	}
}
