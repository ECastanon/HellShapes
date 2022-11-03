using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour {
	
	public GameObject Money;
	bool spawnready = true;
	float time;
	public int startTime = 2;
	public int endTime = 6;
	public bool levelPlayed = false;

	void Start()
	{
		StartCoroutine (CheckSpawn ());
	}

	public void SpawnMoney()
	{
		if (levelPlayed == false) 
		{
			GameObject money = Instantiate (Money) as GameObject;
			money.transform.position = new Vector2(Random.Range(-16, 16), 12);
		}
	}

	IEnumerator CheckSpawn()
	{
		while (spawnready == true)
		{
			time = Random.Range (startTime, endTime);
			yield return new WaitForSeconds (time);
			SpawnMoney();
		}
	}
}
