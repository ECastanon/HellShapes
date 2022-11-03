//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//
//public class LevelSelect : MonoBehaviour
//{
//	public GameObject levelHolder;
//	public GameObject levelIcon;
//	public GameObject thisCanvas;
//	public Vector2 iconSpacing;
//	private Rect panelDimensions;
//	private Rect iconDimensions;
//	public int numOfLevels = 15;
//	private int amountPerPage;
//	private int currentLevelCount;
//
//	// Use this for initialization
//	void Start ()
//	{
//		panelDimensions = levelHolder.GetComponent<RectTransform> ().rect;
//		iconDimensions = levelIcon.GetComponent<RectTransform> ().rect;
//		int maxInRow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
//		int maxInCol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
//		amountPerPage = maxInRow * maxInCol;
//		int totalPages = Mathf.CeilToInt ((float)numOfLevels / amountPerPage);
//		LoadPanels (totalPages);
//	}
//
//	void LoadPanels(int numberOfPanels)
//	{
//		GameObject panelClone = Instantiate(levelHolder) as GameObject;
//
//		for(int i=  1; i <= numberOfPanels; i++)
//		{
//			currentLevelCount++;
//			GameObject panel = Instantiate (panelClone) as GameObject;
//			panel.transform.SetParent (thisCanvas.transform, false);
//			panel.transform.SetParent (levelHolder.transform);
//			panel.name = "Page-" + i;
//			panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i-1), 0);
//			SetUpGrid (panel);
//			int numberOfIcons = i == numberOfPanels ? numOfLevels - currentLevelCount : amountPerPage;
//			LoadIcons (numberOfIcons, panel);
//		}
//		Destroy (panelClone);	
//	}
//
//	void SetUpGrid(GameObject panel)
//	{
//		GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup> ();
//		grid.cellSize = new Vector2 (iconDimensions.width, iconDimensions.height);
//		grid.childAlignment = TextAnchor.MiddleCenter;
//		grid.spacing = iconSpacing;
//	}
//
//	void LoadIcons(int numberOfIcons, GameObject parentObject)
//	{
//		for (int i = 1; i <= numberOfIcons; i++) 
//		{
//			GameObject icon = Instantiate(levelIcon) as GameObject;
//			icon.transform.SetParent (thisCanvas.transform, false);
//			icon.transform.SetParent (parentObject.transform);
//			icon.name = "Level " + i;
//			icon.GetComponentInChildren<TextMeshProUGUI>.SetText ("Level " + currentLevelCount);
//		}
//	}
//	
//	// Update is called once per frame
//	void Update () 
//	{
//		
//	}
//}
