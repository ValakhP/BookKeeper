using UnityEngine;
using System.Collections;

public class Mobile : MonoBehaviour 
{
	private float jumpForce;
	private Vector2 direction;

	private float speed;
	private float slowCoef;
	
	private float destroyTimer;

	void Start () 
	{
		speed = 10;
		slowCoef = 6;
		
		jumpForce = 1;
		destroyTimer = 10 + Random.Range (-2, 2);
		
		direction = new Vector2 (Random.Range (-0.5f, 0.5f), Random.Range (0f, 2f)).normalized;
		GetComponent<Rigidbody2D>().velocity = jumpForce * direction;
		
		GetComponent<Animation>().Stop ();
		
		Destroy (gameObject, destroyTimer);
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Ground") 
		{
			GetComponent<Animation>().Play();
		}
	}
	
	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.name == "Student") 
		{
			GetComponent<Collider2D>().isTrigger = true;
			GetComponent<Rigidbody2D>().gravityScale = 0;

			collider.GetComponent<HeroController>().SlowDown(slowCoef);

			transform.position = Vector2.Lerp(transform.position, 
			                                  collider.transform.position + new Vector3(0.32f * collider.GetComponent<HeroController>().FacingRight, 0.1f, 0), 
			                                  speed * Time.deltaTime);

			transform.localScale = new Vector3(-collider.GetComponent<HeroController>().FacingRight, 1, 1);
		}
	}
}















