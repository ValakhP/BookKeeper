using UnityEngine;
using System.Collections;

public class SessionTimer : MonoBehaviour 
{
	public TextMesh timeText;

	private float sessionTime;
	private float timer;

	private bool play;

	// Use this for initialization
	void Start () 
	{
		timeText.GetComponent<Renderer>().sortingLayerName = "Background";	
		timeText.GetComponent<Renderer>().sortingOrder = 2;

        timer = 0;
		play = false;
	}

	public void SetSessionTime(float time)
	{
		sessionTime = time;
        timer = sessionTime + 1;

		play = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (timer > 0) 
		{
			timer -= Time.deltaTime;
			timeText.text = ((int)timer / 60) + ":" + ((int)timer % 60).ToString("D2");
		} 
		else 
		{
			if (play)
			{
				play = false;
				ChangeRoles();
			}
		}
	}

    public void Stop()
    {
        timer = 0;
        play = false;
    }

	private void ChangeRoles()
	{
        FindObjectOfType<ScreenMessages>().ShowTimeOut();
		
		Controls.Functions.BlockPlayer (0);
		Controls.Functions.BlockPlayer (1);

		GameLogic.Logic.ChangeRoles();
	}
}













