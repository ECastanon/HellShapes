using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotSpawner : MonoBehaviour {
	public bool isNotParent;
	public float Speed;
	public GameObject bulletResource;
	public int numOfBullets;
	public float cooldown;
	public float bulletSpd;
	public Vector2 bulletVelocity;
	public float radius = 2f;

	float timer;

	void Start () {
		timer = cooldown;
	}

	// Update is called once per frame
	void Update ()
	{
		if(timer <= 0)
		{
			SpawnBullets();
			timer = cooldown;
		}
		timer -= Time.deltaTime;
	}

	public GameObject[] SpawnBullets()
	{
		//Spawning
		GameObject[] spawnedBullets = new GameObject[numOfBullets];
		for (int i = 0; i < numOfBullets; i++)
		{
			spawnedBullets[i] = BulletManager.GetBulletFromPool();
			if (spawnedBullets[i] == null)
			{
				spawnedBullets[i] = Instantiate (bulletResource, transform);
			} else {
				spawnedBullets[i].transform.SetParent(transform);
				spawnedBullets[i].transform.localPosition = Vector2.zero;
			}

			if (isNotParent)
			{
				spawnedBullets[i].transform.SetParent(null);
			}
		}
		return spawnedBullets;
	}
}
