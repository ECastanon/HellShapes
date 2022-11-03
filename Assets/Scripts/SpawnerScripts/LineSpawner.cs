using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{
	public bool isNotParent;
	public GameObject bulletResource1; //UP
	public GameObject bulletResource2; //Down
	public GameObject bulletResource3; //Right
	public GameObject bulletResource4; //Left
	public int numOfBullets;
	public float cooldown;
	public float startSpawnTimer; //Begins spawning when timer reach this or below
	public float timer;
	float interval = 1f;

	//Changes the line's direction.
	public int direction;

	void Start () {
		timer = cooldown;
	}

	// Update is called once per frame
	void Update ()
	{
		if (timer <= startSpawnTimer && interval <= 0)
		{
			SpawnBullets();
			interval = .2f;
		}
		interval -= Time.deltaTime;
		if (timer <= 0)
		{
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
				if (direction == 0) { spawnedBullets[i] = Instantiate(bulletResource1, transform); }
				if (direction == 1) { spawnedBullets[i] = Instantiate(bulletResource2, transform); }
				if (direction == 2) { spawnedBullets[i] = Instantiate(bulletResource3, transform); }
				if (direction == 3) { spawnedBullets[i] = Instantiate(bulletResource4, transform); }
			} else {
				spawnedBullets[i].transform.SetParent(transform);
				spawnedBullets[i].transform.localPosition = Vector2.zero;
			}

			if (isNotParent){ spawnedBullets [i].transform.SetParent (null); }
		}
		return spawnedBullets;
	}
}