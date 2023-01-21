using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main menu
/// </summary>	
public class MainMenu : MonoBehaviour
{
	#region Public methods
	
	/// <summary>
	/// Goes to the difficulty menu
	/// </summary>
	public void GoToDifficultyMenu()
    {
		AudioManager.Play(AudioClipName.MenuButtonClick);
		MenuManager.GoToMenu(MenuName.Difficulty);
    }

	/// <summary>
	/// Shows the help menu
	/// </summary>
	public void ShowHelp()
	{
		AudioManager.Play(AudioClipName.MenuButtonClick);
		MenuManager.GoToMenu(MenuName.Help);
	}

	/// <summary>
	/// Exits the game
	/// </summary>
	public void ExitGame()
	{
		AudioManager.Play(AudioClipName.MenuButtonClick);
		Application.Quit();
	}

	#endregion

}
