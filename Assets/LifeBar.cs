using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {
	private float life = 100.0f;
	[Range(0,360)]
	public int Size = 0;
	public GameObject Bar;
	private GameObject[] elements;
	public float Life { 
		get{
			return life;
		}
		set{
			life = value;
			if(life > 100) life = 100;
			if(life < 0) life = 0;
			for(var i = 0; i < Size; i++) {
				if (life *Size /100 > i) {
					elements[i].renderer.enabled = true;
				}else{
					elements[i].renderer.enabled = false;
				}
			}
		}
	}

	void Awake() {
		elements = new GameObject[Size];
		for(var i = 0; i < Size; i++) {
			elements[i] = (GameObject)Instantiate(Bar, transform.position, Quaternion.Euler(new Vector3(0,0,i*360/Size)));
			elements[i].transform.parent = transform;
			elements[i].name = string.Format ("LifeBar({0})",i);
		}
	}
	void Update(){
	}
}
