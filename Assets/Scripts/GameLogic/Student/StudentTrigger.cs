using UnityEngine;
using System.Collections;

public class StudentTrigger : MonoBehaviour 
{
	public HeroController heroController;
	public StudentSkills studentSkills;

	public void SetActive()
	{
		heroController.enabled = true;
		studentSkills.enabled = true;

		gameObject.name = "Student";
		gameObject.layer = 9; //StudentOff change to Student
	}
}
