using UnityEngine;
using System.Collections.Generic;
using System;

public class XboxInput : MonoBehaviour {
	private static Dictionary<KeyCode, Action<float>> inputs;
	
	void Awake() {
		i = new KeyBoardInterface();
		inputs = new Dictionary<KeyCode, Action<float>>(){};
	}
	
	public static InputInterface i;
	void Update () {
		foreach(var k in inputs){
			if(Input.GetKey(k.Key)) {
				k.Value(1.0f);
			}
		}
		var x = Input.GetAxis("Horizontal");
		if ( x != 0 ){
			if(x> 0) {
				i.Fire(InputInterface.Type.RIGHT, Mathf.Abs(x));
			}else{
				i.Fire(InputInterface.Type.LEFT, Mathf.Abs (x));
			}
		}

		var y = Input.GetAxis("Vertical");
		if ( y != 0 ){
			if(y> 0) {
				i.Fire(InputInterface.Type.UP, Mathf.Abs(y));
			}else{
				i.Fire(InputInterface.Type.DOWN, Mathf.Abs (y));
			}
		}
		
		var rx = Input.GetAxis("Horizontal 2");
		if ( rx != 0 ){
			if(rx> 0) {
				i.Fire(InputInterface.Type.SUBRIGHT, Mathf.Abs(rx));
			}else{
				i.Fire(InputInterface.Type.SUBLEFT, Mathf.Abs (rx));
			}
		}

		var ry = Input.GetAxis("Vertical 2");
		if ( ry != 0 ){
			if(ry< 0) {
				i.Fire(InputInterface.Type.SUBUP, Mathf.Abs(ry));
			}else{
				i.Fire(InputInterface.Type.SUBDOWN, Mathf.Abs (ry));
			}
		}

	}
}
