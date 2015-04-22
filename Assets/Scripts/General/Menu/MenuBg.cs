using UnityEngine;
using System.Collections;

public class MenuBg : MonoBehaviour 
{
	private static MenuBg Initialized;
	
	// Use this for initialization
	void Start () 
	{
		if (!Initialized) 
		{
			Initialized = this;
			DontDestroyOnLoad(gameObject);
		} 
		else 
		{
			Destroy(gameObject);
		}
	}

	void FixedUpdate()
	{
		if (Application.loadedLevelName == "PlayMenu") 
		{
			Destroy(gameObject);
		}
	}
}
