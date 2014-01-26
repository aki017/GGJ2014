using UnityEngine;
using System.Collections.Generic;
using System;

public class XboxInput : MonoBehaviour {
	private static Dictionary<KeyCode, Action<float>> inputs;
	
	void Awake() {
		i = new KeyBoardInterface();
		inputs = new Dictionary<KeyCode, Action<float>>(){};
		inputs.Add(KeyCode.JoystickButton0, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton1, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton2, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton3, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton4, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton5, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton6, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton7, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton8, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton9, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton10, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton11, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton12, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton13, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton14, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton15, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton16, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton17, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton18, i.Fire(InputInterface.Type.CHANGE));
		inputs.Add(KeyCode.JoystickButton19, i.Fire(InputInterface.Type.CHANGE));
	}
	
	public static InputInterface i;
	void Update () {
		foreach(var k in inputs){
			if(Input.GetKeyDown(k.Key)) {
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
