using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBulletLeft : MonoBehaviour {

	public float spd;
	Rigidbody2D rb;
	Player target;
	Vector2 moveDirection;

	public int timeAlive;
	public float timer; //Time until the bullet is destroyed

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		//Moves Up
		rb.velocity = new Vector2 (-spd, 0);

		timer = timeAlive;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0){Destroy(gameObject);} //Deletes the bullets
	}

	public void ResetTimer(){
		timer = timeAlive;
	}
}