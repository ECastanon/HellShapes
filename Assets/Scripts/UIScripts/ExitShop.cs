using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitShop : MonoBehaviour
{
	private LoadLevel level;
	public Text InputText;

	void Start()
	{
		InputText.text = (" ");
		level = GameObject.FindGameObjectWithTag("LVManager").GetComponent<LoadLevel> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			InputText.text = ("Press [E] to Exit");
		}
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			if (Input.GetKeyDown("e"))
			{
				level.Load();
			}
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			InputText.text = (" ");
		}
	}
}