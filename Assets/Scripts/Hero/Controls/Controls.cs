using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{
	public static Controls Functions;

	public static PlayerControls[] Player = new PlayerControls[2];
	private static PlayerControls[] tempPlayer = new PlayerControls[2];

	void Start()
	{
		Player[0] = new PlayerControls (KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.J, KeyCode.H);
		Player[1] = new PlayerControls (KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.Keypad2, KeyCode.Keypad1);

		if (!Functions) 
		{
			Functions = this;
		}
	}

	public void ReversePlayers()
	{
		PlayerControls temp = Player[0];
		Player[0] = Player[1];
		Player[1] = temp;
	}

	public void BlockPlayer(int player)
	{
		if (Player [player].Attack != KeyCode.None) 
		{
			tempPlayer [player] = Player [player];
			Player [player] = new PlayerControls (KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None);
		}
	}

	public void UnblockPlayer(int player, float time)
	{
		StartCoroutine (Unblock (player, time));
	}

	private IEnumerator Unblock(int player, float time)
	{
		yield return new WaitForSeconds (time);

		Player [player] = tempPlayer [player];
	}
}





