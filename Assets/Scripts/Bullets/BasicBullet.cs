using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour {

	public Vector2 velocity;
	public float spd;
	public float rotation;

	public int timeAlive;
	public float timer; //Time until the bullet is destroyed

	// Use this for initialization
	void Start () {
		timer = timeAlive;
		transform.rotation = Quaternion.Euler (0, 0, rotation);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (velocity * spd * Time.deltaTime);

		timer -= Time.deltaTime;
		if (timer <= 0){Destroy(gameObject);} //Deletes the bullets
	}

	public void ResetTimer(){
		timer = timeAlive;
	}
}