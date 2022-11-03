using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Player data
	public int MaxHp;
	public int hp;
	public bool hit = false;
	public bool richer = false;
	public bool paid = false;
	Color oldColor;
	private IEnumerator hitstate;
	//Player Immunities
	public float immune = 0f;
	public float bulletInvin; // Player's invincibility after being hit
	float invinTimer; //Player's current invincibility

	//Item Ready?
	public static bool Pink = false;
	public static bool Potion = false;
	public static bool Star = false;
	public static bool Skull = false;
	//Enables when items were used in the current level
	public bool usePink = false;
	public bool usePotion = false;
	public bool useStar = false;
	public bool useSkull = false;

	public AudioSource Fire4;
	public AudioSource Heal1;
	public AudioSource Heal3;
	public AudioSource Saint9;
	public AudioSource Buzzer1;

	// Use this for initialization
	void Start ()
	{
		invinTimer = bulletInvin;
		hp = MaxHp;
	}

	void Update ()
	{
		//Checks player immunities
		if (immune > 0) {
			gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
		} else {
			gameObject.GetComponent<Renderer> ().material.color = Color.white;
		}
		immune -= Time.deltaTime;
		invinTimer -= Time.deltaTime;

		UseItem();

		if (hp <= 0)
		{
			Die();
		}
			
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (immune > 0) {
			//While star is active, bullets deal no damage
			if (collision.tag == "Bullet")
			{
				Destroy (collision.gameObject);
				print (hp);
				invinTimer = bulletInvin;
			}
		} else {
			//Grants invincibility and takes damage on collision
			if (collision.tag == "Bullet" && invinTimer <= 0)
			{
				Destroy (collision.gameObject);
				invinTimer = bulletInvin;
				hit = true;
				hp -= 1;
				//Enables Player Flashing
				hitstate = HitState ();
				StartCoroutine (hitstate);
				print (hp);
			}
			if (collision.tag == "DummyBullet" && invinTimer <= 0)
			{
				invinTimer = bulletInvin;
				hit = true;
				hp -= 1;
				//Enables Player Flashing
				hitstate = HitState ();
				StartCoroutine (hitstate);
				print (hp);
			}
		}
			
		if (collision.tag == "Money")
		{
			Destroy (collision.gameObject);
			richer = true;
			MoneyManager.moneyEarned++;
		}

		if (collision.tag == "PinkHeart" && MoneyManager.MoneyCount >= 17)
		{
			if (Pink == false) 
			{
				MoneyManager.MoneyCount -= 17;
				Pink = true;
				paid = true;
				Destroy (collision.gameObject);
			}
		}

		if (collision.tag == "Potion" && MoneyManager.MoneyCount >= 5) 
		{
			if (Potion == false) 
			{
				MoneyManager.MoneyCount -= 5;
				Potion = true;
				paid = true;
				Destroy (collision.gameObject);
			}
		}

		if (collision.tag == "Star" && MoneyManager.MoneyCount >= 15)
		{
			if (Star == false) 
			{
				MoneyManager.MoneyCount -= 15;
				Star = true;
				paid = true;
				Destroy (collision.gameObject);
			}
		}
		if (collision.tag == "Skull" && MoneyManager.MoneyCount >= 15)
		{
			if (Skull == false) 
			{
				MoneyManager.MoneyCount -= 15;
				Player.Skull = true;
				paid = true;
				Destroy (collision.gameObject);
			}	
		}
	}

	void UseItem()
	{
		//Heals by 2
		if (Input.GetKeyDown ("1"))
		{
			if (Potion == true && hp + 1 < MaxHp)
			{
				Heal1.Play ();
				Potion = false;
				hp = hp + 2;
				usePotion = true;
			} else {
				Buzzer1.Play ();
			}	
		}
	
		//Heals full
		if (Input.GetKeyDown ("2"))
		{
			if (Pink == true && hp + 3 < MaxHp)
			{
				Heal3.Play ();
				Pink = false;
				hp = hp + 4;
				usePink = true;
			} else {
				Buzzer1.Play ();
			}		
		} 
		//Invin for 3s
		if (Input.GetKeyDown ("3"))
		{
			if (Star == true)
			{
				Saint9.Play ();
				Star = false;
				immune = 3f;
				//Enables Player Flashing
				hitstate = HitState ();
				StartCoroutine (hitstate);
				useStar = true;
			} else {
				Buzzer1.Play ();
			}	
		}
	
		//Kills all Bullets
		if (Input.GetKeyDown ("4"))
		{
			if (Skull == true)
			{
				Fire4.Play ();
				Skull = false;
				GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Bullet");
				foreach (GameObject enemy in enemies)
					GameObject.Destroy (enemy);
				useSkull = true;
			} else {
				Buzzer1.Play ();
			}
		}
	}

	//Restarts the Level with starting money and items
	void Die()
	{
		MoneyManager.moneyEarned = 0;
		if (usePotion == true) 
		{
			usePotion = false;
			Potion = true;
		}
		if (usePink == true) 
		{
			usePink = false;
			Pink = true;
		}
		if (useStar == true) 
		{
			useStar = false;
			Star = true;
		}
		if (useSkull == true) 
		{
			useSkull = false;
			Skull = true;
		}
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	}

	//Player flashes while invinTimer > 0
	IEnumerator HitState() 
	{
		float flashspeed = 0f;
		while (invinTimer > 0 || immune > 0)
		{
			oldColor = gameObject.GetComponent<Renderer> ().material.color;
			yield return new WaitForSeconds(.03f - flashspeed);
			gameObject.GetComponent<Renderer> ().material.color = new Color(0.0f, 0.0f, 0.0f);
			yield return new WaitForSeconds(.03f -  flashspeed);
			flashspeed += Time.deltaTime;
		}
	}
}