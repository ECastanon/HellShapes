using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side2Side : MonoBehaviour
{
	public BulletSpawner lrspawner;
	public Vector2 halfscreenSize;

	void Start()
	{
		halfscreenSize = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}

	void Update ()
	{

		if (transform.position.x > halfscreenSize.x)
		{
			lrspawner.moveRight = false;
		}
		if (transform.position.x < -halfscreenSize.x)
		{
			lrspawner.moveRight = true;
		}

		if (lrspawner.moveRight == true)
		{
			transform.position = new Vector2 (transform.position.x + lrspawner.Speed * Time.deltaTime, transform.position.y);
		}
		if (lrspawner.moveRight == false)
		{
			transform.position = new Vector2 (transform.position.x - lrspawner.Speed * Time.deltaTime, transform.position.y);
		}
	}
}