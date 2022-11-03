using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
	
	void Update () {
		if (Player.Star == true) {
			this.GetComponent<Renderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 5.1f);
		} else {
			this.GetComponent<Renderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 1f);
		}
	}
}
