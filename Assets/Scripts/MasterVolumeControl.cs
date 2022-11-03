using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolumeControl : MonoBehaviour {

	[Range(0.0f, 1.0f)]
	public float masterVolume = 1.0f;

	void Update () {
		AudioListener.volume = masterVolume;
	}
}
