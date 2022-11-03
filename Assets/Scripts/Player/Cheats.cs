using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour {

	public bool cheats;
	private Player player;
	private CountDownTimer count;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
		count = GameObject.FindGameObjectWithTag("CDTimer").GetComponent<CountDownTimer> ();
	}

	void Update()
	{
		if (Input.GetKeyDown ("tab") && cheats == true) {
			player.immune = 100f;
			player.hp = player.MaxHp;
			MoneyManager.MoneyCount += 30;
		}
		if (Input.GetKeyDown ("`") && cheats == true) {
			count.countdownTime = 3;
		}
	}
}