using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelect : MonoBehaviour {

	public LoadLevel loader;
	public Button[] button;
	private int leveler = 0;

	void Start()
	{
		loader = GameObject.FindGameObjectWithTag("LVManager").GetComponent<LoadLevel> ();
		leveler = LoadLevel.currLevel + 1 - 3;
		Disabler();
	}

	void Disabler()
	{
		for (int i = leveler; i < button.Length; i++) 
		{
			button [i].interactable = false;
		}
	}
	public void LoadLevel1(){ SceneManager.LoadScene(3); }
	public void LoadLevel2(){ SceneManager.LoadScene(4); }
	public void LoadLevel3(){ SceneManager.LoadScene(5); }
	public void LoadLevel4(){ SceneManager.LoadScene(6); }
	public void LoadLevel5(){ SceneManager.LoadScene(7); }
	public void LoadLevel6(){ SceneManager.LoadScene(8); }
	public void LoadLevel7(){ SceneManager.LoadScene(9); }
	public void LoadLevel8(){ SceneManager.LoadScene(10); }
	public void LoadLevel9(){ SceneManager.LoadScene(11); }
	public void LoadLevel10(){ SceneManager.LoadScene(12); }
	public void LoadLevel11(){ SceneManager.LoadScene(13); }
	public void LoadLevel12(){ SceneManager.LoadScene(14); }
	public void LoadLevel13(){ SceneManager.LoadScene(15); }
	public void LoadLevel14(){ SceneManager.LoadScene(16); }
	public void LoadLevel15(){ SceneManager.LoadScene(17); }
	public void LoadLevel16(){ SceneManager.LoadScene(18); }
	public void LoadShop(){ SceneManager.LoadScene(2); }
	public void LoadLevelSelect1(){ SceneManager.LoadScene(1); }
	public void LoadLevelSelect2(){ SceneManager.LoadScene(19); }
}
