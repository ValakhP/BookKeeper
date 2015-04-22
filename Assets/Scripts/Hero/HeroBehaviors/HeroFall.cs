using UnityEngine;
using System.Collections;

public class HeroFall : HeroBehaviour 
{
	public HeroFall(HeroController newHeroController, Transform newTrasform, Rigidbody2D newRigidbody2D, Transform newGroundCheck, LayerMask newWhatIsGround)
		: base(newHeroController, newTrasform, newRigidbody2D, newGroundCheck, newWhatIsGround)
    {
        maxHorSpeed = 4;
        maxVertSpeed = 10;

        acceleration = new Vector2(10, -0.5f);
    }

    public override void BehaviourUpdate()
    {
		if (Input.GetKey(Controls.Player[heroController.Player].Left))
        {
            rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(-maxHorSpeed, rigidbody2D.velocity.y), acceleration.x * Time.deltaTime);
        }
		else if (Input.GetKey(Controls.Player[heroController.Player].Right))
        {
            rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(maxHorSpeed, rigidbody2D.velocity.y), acceleration.x * Time.deltaTime);
        }
        else
        {
            rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(0, rigidbody2D.velocity.y), acceleration.x * Time.deltaTime);
        }
    }

    public override void BehaviourFixedUpdate()
    {
        if (grounded)
        {
            heroController.SetHeroIdle();
        }

        rigidbody2D.velocity += new Vector2(0, acceleration.y);
    }
}
