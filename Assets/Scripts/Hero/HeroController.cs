using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour 
{
    public Transform groundCheck;
    public LayerMask whatIsGround;

	public HeroSkills heroSkills;
	
    private HeroBehaviour heroBehaviour;
    private HeroIdle heroIdle;
    private HeroRun heroRun;
    private HeroJump heroJump;
	private HeroFall heroFall;

	public int Player;

	public int FacingRight
	{
		get { return heroBehaviour.FacingRight; }
	}

	void Start () 
    {
		heroIdle = new HeroIdle(this, transform, GetComponent<Rigidbody2D>(), groundCheck, whatIsGround);
		heroRun = new HeroRun(this, transform, GetComponent<Rigidbody2D>(), groundCheck, whatIsGround);
		heroJump = new HeroJump(this, transform, GetComponent<Rigidbody2D>(), groundCheck, whatIsGround);
		heroFall = new HeroFall(this, transform, GetComponent<Rigidbody2D>(), groundCheck, whatIsGround);

		heroBehaviour = heroIdle;
	}

	public void SetPlayer(int player)
	{
		Player = player;
	}
	
	void Update () 
    {
        heroBehaviour.Update();
	}

    void FixedUpdate()
    {
        heroBehaviour.FixedUpdate();
    }

	internal void SetHeroFall()
    {
		heroFall.StartConditions (FacingRight);
		heroBehaviour = heroFall;

        GetComponent<Animator>().SetInteger("State", 3);
    }

    internal void SetHeroIdle()
    {
		heroIdle.StartConditions (FacingRight);
        heroBehaviour = heroIdle;

        GetComponent<Animator>().SetInteger("State", 0);
    }

    internal void SetHeroJump()
    {
		heroJump.StartConditions (FacingRight);
        heroBehaviour = heroJump;

        GetComponent<Animator>().SetInteger("State", 3);
    }

    internal void SetHeroRun()
    {
		heroRun.StartConditions (FacingRight);
        heroBehaviour = heroRun;

        GetComponent<Animator>().SetInteger("State", 1);
    }

	public void SlowDown(float acceleration)
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.Lerp (GetComponent<Rigidbody2D>().velocity, new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y), acceleration * Time.deltaTime);
	}
}















