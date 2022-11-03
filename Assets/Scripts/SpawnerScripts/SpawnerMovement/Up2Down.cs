using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up2Down : MonoBehaviour
{
	public BulletSpawner lrspawner;
	private Vector2 halfscreenSize;
	public bool Up = true;

	void Start()
	{
		halfscreenSize = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}


	void Update ()
	{
		if(transform.position.y < -halfscreenSize.y)
		{
			transform.position = new Vector2 (transform.position.x, -halfscreenSize.y);
			Up = true;
		}
		if(transform.position.y > halfscreenSize.y)
		{
			transform.position = new Vector2 (transform.position.x, halfscreenSize.y);
			Up = false;
		}

		if (Up == true)
		{
			transform.position = new Vector2 (transform.position.x, transform.position.y + lrspawner.Speed * Time.deltaTime);
		}
		if (Up == false)
		{
			transform.position = new Vector2 (transform.position.x, transform.position.y - lrspawner.Speed * Time.deltaTime);
		}
	}
}