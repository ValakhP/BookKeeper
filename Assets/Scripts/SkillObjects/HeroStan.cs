using UnityEngine;
using System.Collections;

public class HeroStan : MonoBehaviour 
{
	private float stunTime;

	void Start () 
	{
		stunTime = 2;

		Controls.Functions.BlockPlayer(transform.GetComponentInParent<HeroController> ().Player);
		Controls.Functions.UnblockPlayer(transform.GetComponentInParent<HeroController> ().Player, stunTime);

		transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		Destroy (gameObject, stunTime);
	}
}
