using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour
{
	public float amplitude = 0.5f;
	public float frequency = 1f;
	public bool UpDown = true;

	Vector3 posOffset = new Vector3();
	Vector3 tempPos = new Vector3();

	void Start()
	{
		posOffset = transform.position;
	}
		
	void Update()
	{
		if(UpDown == true)
		{
			// Float up/down with a Sin()
			tempPos = posOffset;
			tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
		}
		if(UpDown == false)
		{
			// Float up/down with a Sin()
			tempPos = posOffset;
			tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
		}

		transform.position = tempPos;
	}
}