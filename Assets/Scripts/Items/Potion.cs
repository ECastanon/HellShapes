using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

	void Update () {
		if (Player.Potion == true) {
			this.GetComponent<Renderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 5.1f);
		} else {
			this.GetComponent<Renderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 1f);
		}
	}
}
