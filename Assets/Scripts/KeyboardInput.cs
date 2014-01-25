﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class KeyboardInput : MonoBehaviour {
	private static Dictionary<KeyCode, Action<float>> inputs;

	void Awake() {
		i = new KeyBoardInterface();
		inputs = new Dictionary<KeyCode, Action<float>>(){};
		inputs.Add (KeyCode.W, i.FireUp);
		inputs.Add (KeyCode.A, i.FireLeft);
		inputs.Add (KeyCode.S, i.FireDown);
		inputs.Add (KeyCode.D, i.FireRight);
		inputs.Add (KeyCode.UpArrow, i.FireSubUp);
		inputs.Add (KeyCode.DownArrow, i.FireSubDown);
		inputs.Add (KeyCode.LeftArrow, i.FireSubLeft);
		inputs.Add (KeyCode.RightArrow, i.FireSubRight);
	}

	public static InputInterface i;
	void Update () {
		foreach(var k in inputs){
			if(Input.GetKey(k.Key)) {
				k.Value(1.0f);
			}
		}
	}
}
