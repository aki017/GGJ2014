using UnityEngine;
using System.Collections.Generic;
using System;

public class XboxInput : MonoBehaviour {
	private static Dictionary<KeyCode, Action<float>> inputs;
	
	void Awake() {
		i = new KeyBoardInterface();
		inputs = new Dictionary<KeyCode, Action<float>>(){};
		inputs.Add (KeyCode.JoystickButton16, i.FireUp);
		inputs.Add (KeyCode.JoystickButton17, i.FireLeft);
		inputs.Add (KeyCode.JoystickButton18, i.FireDown);
		inputs.Add (KeyCode.JoystickButton19, i.FireRight);
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
				i.FireRight(Mathf.Abs(x));
			}else{
				i.FireLeft(Mathf.Abs (x));
			}
		}

		var y = Input.GetAxis("Vertical");
		if ( y != 0 ){
			if(y> 0) {
				i.FireUp(Mathf.Abs(y));
			}else{
				i.FireDown(Mathf.Abs (y));
			}
		}
	}
}
