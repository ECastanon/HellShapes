using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
	public static int MoneyCount = 0; //Total money owned
	public Text MoneyDisplay;
	public static int moneyEarned = 0; //Money earned in one level

	void Update()
	{
		MoneyDisplay.text = "Money: "+ (MoneyCount + moneyEarned);
	}
}
