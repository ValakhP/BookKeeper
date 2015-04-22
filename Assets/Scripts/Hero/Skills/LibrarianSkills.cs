using UnityEngine;
using System.Collections;

public class LibrarianSkills : HeroSkills 
{
	private GameObject book;
	private GameObject mobile;

	private float mobileDelay;
	private float bookDelay;

	private System.DateTime mobileUse;
	private System.DateTime bookUse;

	void Start()
	{
		mobileDelay = 15;
		bookDelay = 3.5f;

		mobileUse = System.DateTime.MinValue;
		bookUse = System.DateTime.MinValue;
	}

	void Update () 
    {
		System.TimeSpan timeSpan = System.DateTime.Now - bookUse;
		if (Input.GetKey(Controls.Player[GetComponent<HeroController>().Player].Attack) && timeSpan.TotalSeconds > bookDelay)
        {
            book = Instantiate(Resources.Load("SkillObjects/Book", typeof(GameObject)), transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity) as GameObject;
            book.GetComponent<Book>().Initialize(GetComponent<HeroController>().FacingRight);

			bookUse = System.DateTime.Now;
        }

		timeSpan = System.DateTime.Now - mobileUse;
		if (Input.GetKey(Controls.Player[GetComponent<HeroController>().Player].Special) && mobile == null && timeSpan.TotalSeconds > mobileDelay)
		{
			mobile = Instantiate(Resources.Load("SkillObjects/Mobile", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;

			mobileUse = System.DateTime.Now;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Student") 
		{
			if (collision.gameObject.GetComponent<HeroController>().enabled)
			{
				collision.gameObject.GetComponent<HeroController>().enabled = false;
				collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

				FindObjectOfType<StudentsController>().RemoveStudent(collision.gameObject);
				GameLogic.Logic.CatchStudent(GetComponentInParent<HeroController>().Player);
			}
		}
	}
}

















