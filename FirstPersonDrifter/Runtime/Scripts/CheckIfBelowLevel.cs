﻿// by @torahhorse
// modified by @igaryhe

// Instructions:
// Place on player. OnBelowLevel will get called if the player ever falls below

using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckIfBelowLevel : MonoBehaviour
{
	public float resetBelowThisY = -30f;
	
	private Vector3 startingPosition;

	private void Awake()
	{
		startingPosition = transform.position;
	}

	private void Update ()
	{
		if( transform.position.y < resetBelowThisY )
		{
			OnBelowLevel();
		}
	}
	
	private void OnBelowLevel()
	{
		// Debug.Log("Player fell below level");
	
		// reset the player
		transform.position = startingPosition;

		// alternatively, you could just reload the current scene using this line:
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
