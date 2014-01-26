using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	private GameObject[] players;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		var max_x = 0f;
		var max_y = 0f;
		var min_x = 1024*3f;
		var min_y = 1024*3f;

		foreach(var obj in players) {
			var p = obj.transform.position;
			if(max_x < p.x) max_x = p.x;
			if(min_x > p.x) min_x = p.x;
			if(max_y < p.y) max_y = p.y;
			if(min_y > p.y) min_y = p.y;
		}
		var zoom_w= -1*(max_x - min_x)/4*1.732f;
		var zoom_h = -1*(max_y - min_y + 60)/4*1.732f;
		var zoom = Mathf.Min(zoom_h,zoom_w, -40.0f);

		transform.position = new Vector3(
			(max_x + min_x) / 2,
			(max_y + min_y) / 2,
			zoom);
	}
}
