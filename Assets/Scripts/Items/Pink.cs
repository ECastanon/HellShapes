using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink : MonoBehaviour {

	void Update () {
		if (Player.Pink == true) {
			this.GetComponent<Renderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 5.1f);
		} else {
			this.GetComponent<Renderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 1f);
		}
	}
}
