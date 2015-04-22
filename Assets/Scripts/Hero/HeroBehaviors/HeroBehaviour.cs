using UnityEngine;
using System.Collections;

public abstract class HeroBehaviour 
{
    protected HeroController heroController;

    protected Transform transform;
    protected Rigidbody2D rigidbody2D;

    protected float maxHorSpeed;
    protected float maxVertSpeed;

    protected Vector2 acceleration;

    public int FacingRight;

    protected bool grounded;
    protected Transform groundCheck;
    protected LayerMask whatIsGround;
    protected float groundRadius;

	public HeroBehaviour(HeroController newHeroController, Transform newTrasform, Rigidbody2D newRigidbody2D, Transform newGroundCheck, LayerMask newWhatIsGround)
    {
        heroController = newHeroController;

        transform = newTrasform;
        rigidbody2D = newRigidbody2D;

        groundCheck = newGroundCheck;
        whatIsGround = newWhatIsGround;

        grounded = false;
        groundRadius = 0.1f;

		FacingRight = -1;
    }

	public void StartConditions(int facingRight)
	{
		FacingRight = facingRight;
	}

    public abstract void BehaviourUpdate();
    public abstract void BehaviourFixedUpdate();

    public void Update()
    {
        BehaviourUpdate();
    }

    public void FixedUpdate()
    {
		Facing ();
        GroundCheck();
        VelocityBounds();

        BehaviourFixedUpdate();
    }

	private void Facing()
	{
		if (rigidbody2D.velocity.x > 0.2f)
		{
			FacingRight = 1;
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (rigidbody2D.velocity.x < -0.2f)
		{
			FacingRight = -1;
			transform.localScale = new Vector3(1, 1, 1);
		}
	}

    private void VelocityBounds()
    {
        if (rigidbody2D.velocity.x > maxHorSpeed || rigidbody2D.velocity.x < -maxHorSpeed)
        {
            rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(maxHorSpeed * Mathf.Sign(rigidbody2D.velocity.x), rigidbody2D.velocity.y), acceleration.x * Time.deltaTime);
        }

        if (rigidbody2D.velocity.y > maxVertSpeed || rigidbody2D.velocity.y < -maxVertSpeed)
        {
            rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(rigidbody2D.velocity.x, maxVertSpeed * Mathf.Sign(rigidbody2D.velocity.y)), acceleration.y * Time.deltaTime);
        }
    }

    protected void GroundCheck()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }
}






