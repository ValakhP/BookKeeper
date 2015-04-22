using UnityEngine;
using System.Collections;

public class HeroJump : HeroBehaviour 
{
    private const int JUMP_FORCE = 10;
    private int jumpForce;

	public HeroJump(HeroController newHeroController, Transform newTrasform, Rigidbody2D newRigidbody2D, Transform newGroundCheck, LayerMask newWhatIsGround)
		: base(newHeroController, newTrasform, newRigidbody2D, newGroundCheck, newWhatIsGround)
    {
        maxHorSpeed = 4;
        maxVertSpeed = 10;

        acceleration = new Vector2(10, -0.5f);

        jumpForce = JUMP_FORCE;
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
        if (jumpForce != 0)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpForce);
            jumpForce = 0;
        }

        if (Mathf.Abs(rigidbody2D.velocity.y) < 0.05f)
        {
            jumpForce = JUMP_FORCE;
            heroController.SetHeroFall();
        }

        rigidbody2D.velocity += new Vector2(0, acceleration.y);
		if (Input.GetKey(Controls.Player[heroController.Player].Up))
        {
            rigidbody2D.velocity -= new Vector2(0, acceleration.y / 2);
        }
    }
}