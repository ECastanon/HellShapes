using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour {

	public int countdownTime;
	public Text countdownDisplay;
	public bool bossRemains = false;
	public static int currLevel = 0;
	private LoadLevel level;

	private void Start()
	{
		countdownDisplay.GetComponent<Text> ().color = Color.white;
		StartCoroutine(Countdown ());
		level = GameObject.FindGameObjectWithTag("LVManager").GetComponent<LoadLevel> ();
	}

	IEnumerator Countdown()
	{
		while (countdownTime > 0)
		{
			countdownDisplay.text = countdownTime.ToString();

			yield return new WaitForSeconds(1f);

			countdownTime--;
			if (countdownTime == 10) 
			{
				countdownDisplay.GetComponent<Text> ().color = Color.red;
			}
		}

		if (countdownTime == 0 && bossRemains == true) {
			countdownDisplay.text = "Boss Attack!";
			yield return new WaitForSeconds (2f);
			countdownDisplay.gameObject.SetActive (false);
		} else {
			countdownDisplay.text = "Finish!";
			//Loads the player into level select
			level.Load();
		}
	}
}