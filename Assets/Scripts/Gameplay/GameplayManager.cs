using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gameplay manager
/// </summary>
public class GameplayManager : MonoBehaviour
{
    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
	{
		// add listener to event manager
		EventManager.AddLastBallLostListener(HandleLastBallLost);
		EventManager.AddBlockDestroyedListener(HandleBlockDestroyed);
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// pause game on escape key if game isn't currently paused
		if (Input.GetKeyDown(KeyCode.Escape) &&
			Time.timeScale != 0)
		{
			MenuManager.GoToMenu(MenuName.Pause);
		}
	}

	#endregion

	#region Private methods

	/// <summary>
	/// Ends the game if the last ball is lost
	/// </summary>
	void HandleLastBallLost()
	{
		AudioManager.Play(AudioClipName.GameLost);
		EndGame();
	}

	/// <summary>
	/// Ends the game if the last block was destroyed
	/// </summary>
	void HandleBlockDestroyed()
	{
		// check for 1 because the last block still exists in the scene
		// when it invokes the event
		if (GameObject.FindGameObjectsWithTag("Block").Length == 1)
		{
			EndGame();
		}
	}

	/// <summary>
	/// Ends the game
	/// </summary>
	void EndGame()
	{
		// instantiate prefab and set score
		GameObject gameOverMessage = Instantiate(Resources.Load("GameOverMessage")) as GameObject;
		GameOverMessage gameOverMessageScript = gameOverMessage.GetComponent<GameOverMessage>();
		GameObject hud = GameObject.FindGameObjectWithTag("HUD");
		HUD hudScript = hud.GetComponent<HUD>();
		gameOverMessageScript.SetScore(hudScript.Score);
	}

	#endregion
}
