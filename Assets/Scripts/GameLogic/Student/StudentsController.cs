using UnityEngine;
using System.Collections;

public class StudentsController : MonoBehaviour 
{
	public GameObject students;
	private GameObject tempStudents;

	private StudentTrigger[] studentTriggers;

	public StudentTrigger currentStudent;

	// Use this for initialization
	void Awake () 
	{
		studentTriggers = students.GetComponentsInChildren<StudentTrigger> ();

		tempStudents = Instantiate (students) as GameObject;
		tempStudents.SetActive (false);
	}
	
	public HeroController RandomStudentController()
	{
		currentStudent = studentTriggers [Random.Range (0, studentTriggers.Length)];
		currentStudent.SetActive ();

		return currentStudent.heroController;
	}

	public void RemoveStudent(GameObject student)
	{
		if (studentTriggers.Length > 1)
		{
			var temp = new System.Collections.Generic.List<StudentTrigger> ();

			temp.AddRange (studentTriggers);
			temp.Remove (student.GetComponent<StudentTrigger> ());
			Destroy (student, 2); //Destroy above the score animation

			studentTriggers = temp.ToArray ();

			StartCoroutine(ChangeStudent());
		} 
		else 
		{
			Destroy (student, 2); //Destroy above the score animation

			if (GameLogic.Logic.RoundNum < 2)
			{
				StartCoroutine(ChangeRoles());
			}
			else
			{
				GameLogic.Logic.ChangeRoles ();
			}
		}
	}
	
	private IEnumerator ChangeStudent()
	{
		yield return new WaitForSeconds(3);
		GameLogic.Logic.NextStudent ();
	}

	private IEnumerator ChangeRoles()
	{
		yield return new WaitForSeconds (2);
		GameLogic.Logic.ChangeRoles ();
	}

	public void NewRound()
	{
		Destroy(students.gameObject);
		students = tempStudents;
		students.name = "Students";
		students.SetActive (true);
		
		studentTriggers = students.GetComponentsInChildren<StudentTrigger> ();
		
		tempStudents = Instantiate (students) as GameObject;
		tempStudents.SetActive (false);
	}
}






