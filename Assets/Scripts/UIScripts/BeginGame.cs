using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour {

	private GameHandler gh;

	void Start()
	{
		gh = GameObject.Find ("GameHandler").GetComponent<GameHandler>();
		//gh.saveData ();
		gh.loadData ();
	}

	public void gameStart() { SceneManager.LoadScene (1); }
}
