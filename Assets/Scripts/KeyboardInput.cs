using UnityEngine;
using System.Collections.Generic;
using System;

public class KeyboardInput : MonoBehaviour {
	private static Dictionary<KeyCode, Action<float>> inputs;

	void Awake() {
		i = new KeyBoardInterface();
		inputs = new Dictionary<KeyCode, Action<float>>(){};
		inputs.Add (KeyCode.W, i.Fire(InputInterface.Type.UP));
		inputs.Add (KeyCode.A, i.Fire(InputInterface.Type.LEFT));
		inputs.Add (KeyCode.S, i.Fire(InputInterface.Type.DOWN));
		inputs.Add (KeyCode.D, i.Fire(InputInterface.Type.RIGHT));
		inputs.Add (KeyCode.UpArrow, i.Fire(InputInterface.Type.SUBUP));
		inputs.Add (KeyCode.DownArrow, i.Fire(InputInterface.Type.SUBDOWN));
		inputs.Add (KeyCode.LeftArrow, i.Fire(InputInterface.Type.SUBLEFT));
		inputs.Add (KeyCode.RightArrow, i.Fire(InputInterface.Type.SUBRIGHT));

	}

	public static InputInterface i;
	void Update () {
		foreach(var k in inputs){
			if(Input.GetKey(k.Key)) {
				k.Value(1.0f);
			}
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			i.Fire(InputInterface.Type.CHANGE, 1.0f);
		}
	}
}
