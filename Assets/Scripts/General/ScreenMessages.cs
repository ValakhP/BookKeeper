using UnityEngine;
using System.Collections;

public class ScreenMessages : MonoBehaviour 
{
	public GameObject blackScreen;
	public SpriteRenderer labelRenderer;
	public Sprite[] labels;

    private ArrayList labelsList;
	private bool isActive;

	void Start()
	{
		isActive = false;
        labelsList = new ArrayList();
	}

	public bool isShowing()
	{
		return isActive;
	}

	public void ShowRound1()
	{
        labelsList.Add(2);
        AddToShow();
	}

	public void ShowRound2()
	{
        labelsList.Add(0);
        AddToShow();
	}
	
	public void ShowTimeOut()
	{
        labelsList.Add(1);
        AddToShow();
	}

    private void AddToShow()
    {
        if (!isActive)
        {
            Show();
        }
    }

	private void Show()
	{
        if (isActive)
        {
            if (labelsList.Count > 0)
            {
                labelRenderer.sprite = labels[(int)labelsList[0]];
                labelsList.RemoveAt(0);

                StartCoroutine(ShowLabel());
            }
            else
            {
                StartCoroutine(HideBg());
            }
        }
        else
        {
            ShowBg();
        }
	}

	private IEnumerator ShowLabel()
	{
		yield return new WaitForSeconds (0.5f);
        GetComponent<Animation>().Play("LabelAppear");

        yield return new WaitForSeconds(1.5f);
        GetComponent<Animation>().Play("LabelDisappear");

        yield return new WaitForSeconds(0.3f);
        Show();
	}

    public void ShowBg()
    {
        blackScreen.GetComponent<Animation>().Play("BgAppear");
        isActive = true;

        Show();
    }

    private IEnumerator HideBg()
    {
        if (!GameLogic.Logic.isEnd())
        {
            yield return new WaitForSeconds(0.5f);

            blackScreen.GetComponent<Animation>().Play("BgDisappear");
            isActive = false;
        }
    }
}






