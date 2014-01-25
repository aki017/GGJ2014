using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {
	private float life = 0.0f;
	public float Life { 
		set{
			life = value;
			if(life > 100) life = 100;
			transform.localScale = new Vector3(0.4f*life/100,0.4f, 1f);
		}
	}
	void Update(){
		Life = life + Random.value;
	}
}
