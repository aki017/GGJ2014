using UnityEngine;
using System.Collections;

public class BGMService : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
        var audios = GetComponents<AudioSource>();
        audios[0].Play();
        audios[1].PlayDelayed((ulong)audios[0].clip.samples);
	}
}
