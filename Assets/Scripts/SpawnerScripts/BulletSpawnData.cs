using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BulletSpawnData", order = 1)]

public class BulletSpawnData : ScriptableObject {
	public GameObject bulletResource;
	public float minRot;
	public float maxRot;
	public int numOfBullets;
	public bool isRandom;
	public bool isNotParent;
	public float cooldown;
	public float bulletSpd;
	public Vector2 bulletVelocity;
}
