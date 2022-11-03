using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

	public BulletSpawnData[] spawnDatas;
	public int index = 0;
	public bool isSequenceRandom;
	public bool spawnAutomatically;
	public bool isNotParent;
	public float Speed;
	public bool moveRight = true;
	public int startup = 0;

	BulletSpawnData GetSpawnData()
	{
		return spawnDatas[index];
	}

	float timer;

	float[] rotations;

	void Start () {
		timer = GetSpawnData().cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		if (startup <= 0) {
			if (spawnAutomatically) {
				if (timer <= 0) {
					SpawnBullets ();
					timer = GetSpawnData ().cooldown;
					if (isSequenceRandom) {
						index = Random.Range (0, spawnDatas.Length);
					} else {
						index += 1;
						if (index >= spawnDatas.Length)
							index = 0;
					}
					rotations = new float[GetSpawnData ().numOfBullets];
				}
				timer -= Time.deltaTime;
			}
		} else {
			startup--;
		}

	}
	//Used to randomly disribute bullets
	public float[] RandomRotations(){
		for (int i = 0; i < GetSpawnData().numOfBullets; i++) {
			rotations [i] = Random.Range (GetSpawnData().minRot, GetSpawnData().maxRot);
		}
		return rotations;
	}

	//Used to evenly distribute bullets
	public float[] DistributedRotations()
	{
		for (int i = 0; i < GetSpawnData().numOfBullets; i++){
		
			var fraction = (float)i / ((float)GetSpawnData().numOfBullets - 1);
			var difference = GetSpawnData().maxRot - GetSpawnData().minRot;
			var fractionOfDifference = fraction * difference;
			rotations [i] = fractionOfDifference + GetSpawnData().minRot;
		}
		foreach (var r in rotations)print (r);
		return rotations;
	}

	public GameObject[] SpawnBullets()
	{
		rotations = new float[GetSpawnData().numOfBullets];
		if (GetSpawnData ().isRandom) {
			RandomRotations ();
		} else {
			DistributedRotations();
		}

		//Spawning
		GameObject[] spawnedBullets = new GameObject[GetSpawnData().numOfBullets];
		for (int i = 0; i < GetSpawnData().numOfBullets; i++)
		{
			spawnedBullets[i] = BulletManager.GetBulletFromPool();
			if (spawnedBullets[i] == null)
			{
				spawnedBullets[i] = Instantiate (GetSpawnData().bulletResource, transform);
			} else
			{
				spawnedBullets[i].transform.SetParent(transform);
				spawnedBullets[i].transform.localPosition = Vector2.zero;
			}
			var b = spawnedBullets[i].GetComponent<BasicBullet>();
			b.rotation = rotations[i];
			b.spd = GetSpawnData().bulletSpd;
			b.velocity = GetSpawnData().bulletVelocity;
			if (isNotParent) {spawnedBullets[i].transform.SetParent(null);}
		}
		return spawnedBullets;
	}
}

