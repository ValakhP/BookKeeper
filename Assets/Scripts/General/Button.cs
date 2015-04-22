using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour 
{
	public Sprite normal;
	public Sprite hover;

	public string loadLevel;

	// Use this for initialization
	void OnPointerUpAsButton () 
	{
		if (loadLevel != "Exit") 
		{
			Application.LoadLevel (loadLevel);
		} 
		else 
		{
			Application.Quit();
		}
	}

	void OnMouseEnter()
	{
		GetComponent<SpriteRenderer> ().sprite = hover;
	}

	void OnMouseExit()
	{
		GetComponent<SpriteRenderer> ().sprite = normal;
	}
}
