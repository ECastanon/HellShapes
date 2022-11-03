using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LoadLevel : MonoBehaviour {

	public static int currLevel = 3;
	private MoneySpawner msp;
	private GameHandler gh;

	void Start()
	{
		Debug.Log ("The current level is: " + (currLevel - 3 + 1));
		Scene scene = SceneManager.GetActiveScene();
		msp = GameObject.Find ("MoneySpawner").GetComponent<MoneySpawner>();
		gh = GameObject.Find ("GameHandler").GetComponent<GameHandler>();

		//Checks at start if the level has been beaten before
		if (scene.buildIndex > 2) {
			if (scene.buildIndex < currLevel)
			{
				msp.levelPlayed = true;
			} else {
				msp.levelPlayed = false;
			}
		}
		if (scene.buildIndex == 1 || scene.buildIndex == 2) { msp.levelPlayed = true; }
	}

	public void Load()
	{
		MoneyManager.MoneyCount += MoneyManager.moneyEarned;
		MoneyManager.moneyEarned = 0;
		Scene scene = SceneManager.GetActiveScene();

		//Loads level select from shop
		if (scene.buildIndex == 2) {
			SceneManager.LoadScene (1);
		} else {
			if (scene.buildIndex < currLevel)
			{
				msp.levelPlayed = true;
			} else {
				msp.levelPlayed = false;
			}
		}

		//Checks if user was in a played game level and loads level select if all true
		if (scene.buildIndex >= 3 && scene.buildIndex <= 17)
		{
			if (msp.levelPlayed == false) {
				currLevel += 1;
				SceneManager.LoadScene (1);
			} else {
				SceneManager.LoadScene (1);
			}
		}
		if (scene.buildIndex == 18)
		{
			SceneManager.LoadScene (1);
		}
		//Calls the saveData function from the GameHandler script after the scene changes
		gh.saveData();
	}
}