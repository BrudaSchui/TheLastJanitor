using UnityEngine;

public class Player : MonoBehaviour
{
	private float speed = 2;
	private float taskEnterTime;

	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		// if (y != 0) x = y * 0.5f;

		Vector2 direction = new Vector2(x, y).normalized;

		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}