using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float spd;

	public Vector2 halfscreenSize;
	public float halfPlayerWidth;
	public float halfPlayerHeight;

	void Start()
	{
		halfPlayerWidth = transform.localScale.x / -2;
		halfPlayerHeight = transform.localScale.x / -2;
		halfscreenSize = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize + halfPlayerHeight, Camera.main.orthographicSize + halfPlayerWidth);
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position += new Vector3 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * spd * Time.deltaTime;
		Bounds ();
	}

	void Bounds()
	{
		if(transform.position.x < -halfscreenSize.x)
		{
			transform.position = new Vector2 (-halfscreenSize.x, transform.position.y);
		}
		if(transform.position.x > halfscreenSize.x)
		{
			transform.position = new Vector2 (halfscreenSize.x, transform.position.y);
		}
		if(transform.position.y < -halfscreenSize.y)
		{
			transform.position = new Vector2 (transform.position.x, -halfscreenSize.y);
		}
		if(transform.position.y > halfscreenSize.y)
		{
			transform.position = new Vector2 (transform.position.x, halfscreenSize.y);
		}
	}
}
