using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {
	
	public float Speed;
	public bool moveRight = true;
	public bool Approach = true;
	public Transform player;

	public int boss = 0;

	// Update is called once per frame
	void Update ()
	{
		//Plays Boss1
		if (boss == 1)
		{
			ApproachPlayer();
		}

		//Plays Boss2
		if (boss == 2)
		{
			ApproachPlayer();
		}

	}
	public void ApproachPlayer()
	{
		transform.transform.LookAt(player.position);
		transform.Rotate(new Vector3(0, -90, 0), Space.Self);

		if(Vector3.Distance(transform.position, player.position) > 1f)
		{
			transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
		}
	}
}
