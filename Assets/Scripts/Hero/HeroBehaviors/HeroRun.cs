using UnityEngine;
using System.Collections;

public class HeroRun : HeroBehaviour 
{
	public HeroRun(HeroController newHeroController, Transform newTrasform, Rigidbody2D newRigidbody2D, Transform newGroundCheck, LayerMask newWhatIsGround)
        : base(newHeroController, newTrasform, newRigidbody2D, newGroundCheck, newWhatIsGround)
    {
        maxHorSpeed = 4;
        maxVertSpeed = 5;

        acceleration = new Vector2(10, 0.1f);
    }

    public override void BehaviourUpdate()
    {
		if (Input.GetKey(Controls.Player[heroController.Player].Left))
        {
            if (rigidbody2D.velocity.x > 0)
            {
                rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(-maxHorSpeed, rigidbody2D.velocity.y), 2 * acceleration.x * Time.deltaTime);
            }
            else
            {
                rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(-maxHorSpeed, rigidbody2D.velocity.y), acceleration.x * Time.deltaTime);
            }
        }
		else if (Input.GetKey(Controls.Player[heroController.Player].Right))
        {
            if (rigidbody2D.velocity.x < 0)
            {
                rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(maxHorSpeed, rigidbody2D.velocity.y), 2 * acceleration.x * Time.deltaTime);
            }
            else
            {
                rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(maxHorSpeed, rigidbody2D.velocity.y), acceleration.x * Time.deltaTime);
            }
        }
        else
        {
            heroController.SetHeroIdle();
        }

		if (Input.GetKey(Controls.Player[heroController.Player].Up))
        {
            heroController.SetHeroJump();
        }
    }

    public override void BehaviourFixedUpdate()
    {
        if (!grounded)
        {
            heroController.SetHeroFall();
        }
    }
}
