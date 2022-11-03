using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

//	private IUnit unit;
//
//	// Use this for initialization
//	void Awake ()
//	{
//		unit = unitGameObject.GetComponent<IUnit> ();
//	}


	//Saves player's level count, money, and items
	public void saveData()
	{
		PlayerPrefs.SetInt ("levelCount", LoadLevel.currLevel);
		PlayerPrefs.SetInt ("playerMoney", MoneyManager.MoneyCount);
		//Saves Items
		if(Player.Potion == true){PlayerPrefs.SetInt ("playerPotion", 1);} else{PlayerPrefs.SetInt ("playerPotion", 0);}
		if(Player.Pink == true){PlayerPrefs.SetInt ("playerPink", 1);} else{PlayerPrefs.SetInt ("playerPink", 0);}
		if(Player.Star == true){PlayerPrefs.SetInt ("playerStar", 1);} else{PlayerPrefs.SetInt ("playerStar", 0);}
		if(Player.Skull == true){PlayerPrefs.SetInt ("playerSkull", 1);} else{PlayerPrefs.SetInt ("playerSkull", 0);}
		Debug.Log("SAVED");
	}
	//Loads player's level count, money, and items
	public void loadData()
	{
		LoadLevel.currLevel = PlayerPrefs.GetInt ("levelCount");
		if (LoadLevel.currLevel == 0) {LoadLevel.currLevel = 3;}
		MoneyManager.MoneyCount = PlayerPrefs.GetInt ("playerMoney");
		//LoadsItems
		if(PlayerPrefs.GetInt("playerPotion") == 1){Player.Potion = true;} else {Player.Potion = false;}
		if(PlayerPrefs.GetInt("playerPink") == 1){Player.Pink = true;} else {Player.Pink = false;}
		if(PlayerPrefs.GetInt("playerStar") == 1){Player.Star = true;} else {Player.Star = false;}
		if(PlayerPrefs.GetInt("playerSkull") == 1){Player.Skull = true;} else {Player.Skull = false;}
		Debug.Log("LOADED");
	}
}
