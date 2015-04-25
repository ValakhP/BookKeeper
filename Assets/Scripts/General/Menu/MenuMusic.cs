using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour 
{
	private static MenuMusic Initialized;

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

	void OnLevelWasLoaded(int level)
	{
		if (Application.loadedLevelName == "PlayMenu") 
		{
			Destroy(gameObject);
		}
	}
}
