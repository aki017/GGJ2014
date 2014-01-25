using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {
	private float life = 100.0f;
	public float Life { 
		get{
			return life;
		}
		set{
			life = value;
			if(life > 100) life = 100;
			if(life < 0) life = 0;
			transform.localScale = new Vector3(0.4f*life/100,0.4f, 1f);
		}
	}
	void Update(){
	}
}
