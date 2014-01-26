using UnityEngine;
using System.Collections;

public class TutorialCamera : MonoBehaviour {
	public GameObject[] images;
	public int i = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine(T ());
			for(var j = 0; j < images.Length; j++) {
				if(i==j) {
					images[j].SetActive(true);
				}else{
					images[j].SetActive(false);
				}
			}
	
	}
	
	// Update is called once per frame
	IEnumerator T () {
		while(true) {
			if(Input.anyKey){
				i++;
			for(var j = 0; j < images.Length; j++) {
				if(i==j) {
					images[j].SetActive(true);
				}else{
					images[j].SetActive(false);
				}
			}
				yield return new WaitForSeconds(1f);
			}
			yield return null;
			if(i == images.Length) {
				Application.LoadLevel("Main");
			}
		}
	}
}
