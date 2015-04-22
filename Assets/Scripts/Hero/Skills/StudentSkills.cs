using UnityEngine;
using System.Collections;

public class StudentSkills : HeroSkills 
{
	private GameObject page;
	private int pageCount;

	private float pagesDelay;
	private float timer;

	private System.DateTime pagesUse;

	void Start()
	{
		pageCount = 5;
		pagesDelay = 12;

		pagesUse = System.DateTime.MinValue;
	}

	void Update () 
	{
		System.TimeSpan timeSpan = System.DateTime.Now - pagesUse;
		if (Input.GetKey(Controls.Player[GetComponent<HeroController>().Player].Attack) && timeSpan.TotalSeconds > pagesDelay)
		{
			for (int i = 0; i < pageCount; i++)
			{
				page = Instantiate(Resources.Load("SkillObjects/Page", typeof(GameObject)), transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity) as GameObject;
			}

			pagesUse = System.DateTime.Now;
		}
	}
}
