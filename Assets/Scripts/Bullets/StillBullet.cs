using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillBullet : MonoBehaviour {

	public int timeAliveS;
	public float timer;

	// Use this for initialization
	void Start () {
		timer = timeAliveS;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		//if (timer <= 0) gameObject.SetActive(false); //Disables bullets to be reused
		if (timer <= 0){Destroy(gameObject);} //Deletes the bullets
	}

	public void ResetTimer(){
		timer = timeAliveS;
	}
}
