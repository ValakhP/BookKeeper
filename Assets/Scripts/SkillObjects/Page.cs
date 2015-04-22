using UnityEngine;
using System.Collections;

public class Page : MonoBehaviour 
{
	private float jumpForce;
	private Vector2 direction;

	private float slowCoef;

	private float destroyTimer;
	
	void Start () 
	{
		slowCoef = 2;

		jumpForce = 3;
		destroyTimer = 10 + Random.Range (-2, 2);

		direction = new Vector2 (Random.Range (-0.5f, 0.5f), Random.Range (0f, 2f)).normalized;
		GetComponent<Rigidbody2D>().velocity = jumpForce * direction;

		GetComponent<Animation>().Stop ();

		Destroy (gameObject, destroyTimer);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Librarian") 
		{
			Destroy (gameObject);
		} 
		else if (collision.gameObject.name == "Ground") 
		{
			GetComponent<Animation>().Play();
		}
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.name == "Librarian") 
		{
			collider.GetComponent<HeroController>().SlowDown(slowCoef);
		}
	}
}
