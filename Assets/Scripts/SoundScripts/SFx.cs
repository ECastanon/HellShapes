using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFx : MonoBehaviour
{
	public AudioSource Attack2;
	public AudioSource Collapse3;
	public AudioSource Cursor2;
	public AudioSource Buzzer1;
	public AudioSource Coin;
	public AudioSource Fire4;
	public AudioSource Heal1;
	public AudioSource Heal3;
	public AudioSource Saint9;

	private Player player;
	private Player play = new Player ();

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
	}
	void Update()
	{
		playerHit();
		playerRich();
		playerPay();
	}

	void playerHit()
	{
		if (player.hit == true)
		{
			player.hit = false;
			Attack2.Play();
		}
	}
	void playerRich()
	{
		if (player.richer == true)
		{
			player.richer = false;
			Cursor2.Play();
		}
	}

	void playerPay()
	{
		if (player.paid == true)
		{
			Coin.Play ();
			player.paid = false;
		}
	}
}

