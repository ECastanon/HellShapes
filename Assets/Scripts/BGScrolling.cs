using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{

	private float ScrollSpeed = 1f;

	void Update ()
	{
		Scroll();
	}
		
	void Scroll()
	{
		transform.Translate(new Vector3(0, ScrollSpeed * Time.deltaTime, 0));
		if(transform.position.y > 30)
		{
			transform.position = new Vector3(0, -30, 0);
		}
	}
}