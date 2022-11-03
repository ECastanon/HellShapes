using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBullet : MonoBehaviour {

	public Vector2 velocity;
	public float spd;
	public float rotation;

	public Vector2 halfscreenSize;
	public float halfBullWidth;
	public float halfBullHeight;

	public int timeAlive;
	public float timer; //Time until the bullet is destroyed

	// Use this for initialization
	void Start () {
		halfBullWidth = transform.localScale.x / -2;
		halfBullHeight = transform.localScale.x / -2;
		halfscreenSize = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize + halfBullHeight, Camera.main.orthographicSize + halfBullWidth);

		timer = timeAlive;
		transform.rotation = Quaternion.Euler (0, 0, rotation);
	}

	// Update is called once per frame
	void Update () {
		Bounds();
		transform.Translate (velocity * spd * Time.deltaTime);

		timer -= Time.deltaTime;
		if (timer <= 0){Destroy(gameObject);} //Deletes the bullets
	}

	public void ResetTimer(){
		timer = timeAlive;
	}

	void Bounds()
	{
		if(transform.position.x < -halfscreenSize.x){spd = -1 * spd;}
		if(transform.position.x > halfscreenSize.x){spd = -1 * spd;}
		if(transform.position.y < -halfscreenSize.y){spd = -1 * spd;}
		if(transform.position.y > halfscreenSize.y){spd = -1 * spd;}
	}
}