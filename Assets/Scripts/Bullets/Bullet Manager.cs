using UnityEngine;
using System.Collections.Generic;
public class BulletManager : MonoBehaviour
{
	public static List<GameObject> bullets = new List<GameObject>();

	public static GameObject GetBulletFromPool()
	{
		for (int i = 0; i < bullets.Count; i++)
		{
			if (!bullets[i].active)
			{
				bullets[i].GetComponent<BasicBullet>().ResetTimer();
				bullets[i].SetActive(true);
				return bullets[i];
			}
		}
		return null;
	}
}