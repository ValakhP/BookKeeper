using UnityEngine;
using System.Collections;

public class HeroIdle : HeroBehaviour
{
	public HeroIdle(HeroController newHeroController, Transform newTrasform, Rigidbody2D newRigidbody2D, Transform newGroundCheck, LayerMask newWhatIsGround) 
		: base(newHeroController, newTrasform, newRigidbody2D, newGroundCheck, newWhatIsGround)
    {
        maxHorSpeed = 0;
        maxVertSpeed = 0;

        acceleration = new Vector2(10, 0);
    }

    public override void BehaviourUpdate()
    {
		if (Input.GetKey(Controls.Player[heroController.Player].Left) || Input.GetKey(Controls.Player[heroController.Player].Right))
        {
            heroController.SetHeroRun();
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

        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
    }
}
