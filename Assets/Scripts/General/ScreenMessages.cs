using UnityEngine;
using System.Collections;

public class ScreenMessages : MonoBehaviour 
{
	public GameObject blackScreen;
	public SpriteRenderer labelRenderer;
	public Sprite[] labels;

	private bool isBlackScreen;

	void Start()
	{
		isBlackScreen = false;
	}

	public bool isShowing()
	{
		return isBlackScreen;
	}

	public void ShowRound1()
	{
		blackScreen.GetComponent<Animation>().Play("BgAppear");
		labelRenderer.sprite = labels [2];

		Show ();
	}

	public void ShowRound2(bool newLabel)
	{
		if (newLabel) 
		{
			blackScreen.GetComponent<Animation>().Play("BgAppear");
		}

		labelRenderer.sprite = labels [0];
		Show ();
	}

	public bool ShowBlackScreen()
	{
		if (isBlackScreen) 
		{
			return false;
		} 
		else 
		{
			blackScreen.GetComponent<Animation>().Play("BgAppear");
			return true;
		}
	}
	
	public void ShowTimeOut()
	{
		blackScreen.GetComponent<Animation>().Play("BgAppear");

		labelRenderer.sprite = labels [1];
		Show ();
	}

	private void Show()
	{
		isBlackScreen = true;

		GetComponent<Animation>().Play ("LabelAppear");
		StartCoroutine (Disappear ());
	}

	private IEnumerator Disappear()
	{
		yield return new WaitForSeconds (2);
		GetComponent<Animation>().Play ("LabelDisappear");

		if (labelRenderer.sprite == labels [0]) 
		{
			yield return new WaitForSeconds (0.2f);
			if (GameLogic.Logic.RoundNum < 2) 
			{
				blackScreen.GetComponent<Animation>().Play ("BgDisappear");
				isBlackScreen = false;
			}
		} 
		else if (labelRenderer.sprite == labels [1]) 
		{
			if (GameLogic.Logic.RoundNum < 2) 
			{
				yield return new WaitForSeconds (0.5f);
				ShowRound2 (false);
			} 
			else 
			{
				yield return new WaitForSeconds (0.5f);

			}
		} 
		else 
		{
			blackScreen.GetComponent<Animation>().Play ("BgDisappear");
			isBlackScreen = false;
		}
	}
}






