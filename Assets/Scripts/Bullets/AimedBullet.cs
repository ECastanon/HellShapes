using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedBullet : MonoBehaviour {
	
	public float spd;
	Rigidbody2D rb;
	Player target;
	Vector2 moveDirection;

	public int timeAlive;
	public float timer; //Time until the bullet is destroyed

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<Player>();
		moveDirection = (target.transform.position - transform.position).normalized * spd;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);

		timer = timeAlive;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		//if (timer <= 0) gameObject.SetActive(false); //Disables bullets to be reused
		if (timer <= 0){Destroy(gameObject);} //Deletes the bullets
	}

	public void ResetTimer(){
		timer = timeAlive;
	}
}
