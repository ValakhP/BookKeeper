using UnityEngine;
using System.Collections;

public class PlayerControls
{
	public KeyCode Left;
	public KeyCode Right;
	public KeyCode Up;
	public KeyCode Attack;
	public KeyCode Special;
	
	public PlayerControls(KeyCode left, KeyCode right, KeyCode up, KeyCode attack, KeyCode special)
	{
		Left = left;
		Right = right;
		Up = up;
		Attack = attack;
		Special = special;
	}
}
