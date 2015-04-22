using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour 
{
	public TextMesh player1Text;
	public TextMesh player2Text;

	public int Player1Score;
	public int Player2Score;

	public Animation winnerAnimation;
	public Transform winner;

	// Use this for initialization
	void Start () 
	{
		Player1Score = 0;
		Player2Score = 0;

		player1Text.GetComponent<Renderer>().sortingLayerName = "Foreground";	
		player1Text.GetComponent<Renderer>().sortingOrder = 1;
		player2Text.GetComponent<Renderer>().sortingLayerName = "Foreground";	
		player2Text.GetComponent<Renderer>().sortingOrder = 1;
	}
	
	public void AddScore(int player)
	{
		GameObject scoreLable = Instantiate(Resources.Load("Score/ScoreLabel", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
		Destroy (scoreLable, 5);

		if (player == 0) 
		{
			Player1Score++;
			player1Text.text = Player1Score.ToString();
		} 
		else 
		{
			Player2Score++;
			player2Text.text = Player2Score.ToString();
		}

		winner.localScale = new Vector3(Mathf.Sign (Player2Score - Player1Score), 1, 1);
	}

	public void ShowResults()
	{
		StartCoroutine (Results ());
	}

	private IEnumerator Results()
	{
		winnerAnimation.GetComponent<Animation>().Play ("LabelAppear");
		
		yield return new WaitForSeconds (1);
		winnerAnimation.GetComponent<Animation>().Play ("WinnerAppear");
	}
}





















