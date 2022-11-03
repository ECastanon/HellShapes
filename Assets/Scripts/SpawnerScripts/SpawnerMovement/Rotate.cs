using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public RotSpawner lrspawner;

	private Vector2 center;
	private float angle;

	private void Start()
	{
		center = transform.position;
	}

	void Update ()
	{
		angle += lrspawner.Speed * Time.deltaTime;

		var offset = new Vector2 (Mathf.Sin(angle), Mathf.Cos(angle)) * lrspawner.radius;
		transform.position = center + offset;
	}
}
