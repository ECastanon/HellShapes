using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFall : MonoBehaviour {
	public float fallspd = 1.5f;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, transform.position.y - fallspd * Time.deltaTime);
		if (transform.position.y < -12f) {
			Destroy(gameObject);
		}	
	}
}
