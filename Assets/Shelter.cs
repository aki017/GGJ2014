using UnityEngine;
using System.Collections;

public class Shelter : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D other) {
		other.SendMessage("Erase");
	}
}
