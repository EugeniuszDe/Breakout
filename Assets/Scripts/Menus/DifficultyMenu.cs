using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The difficulty menu
/// </summary>
public class DifficultyMenu : MonoBehaviour
{
    // events invoked by the class
    GameStartedEvent gameStartedEvent = new GameStartedEvent();

    #region Unity methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // add invoker to event manager
        EventManager.AddGameStartedInvoker(this);
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Adds the given listener for the game started event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        gameStartedEvent.AddListener(listener);
    }

    /// <summary>
    /// Starts an easy game
    /// </summary>
    public void StartEasyGame()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Difficulty.Easy);
    }

    /// <summary>
    /// Starts a medium game
    /// </summary>
    public void StartMediumGame()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Difficulty.Medium);
    }

    /// <summary>
    /// Starts a hard game
    /// </summary>
    public void StartHardGame()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        gameStartedEvent.Invoke(Difficulty.Hard);
    }

    #endregion
}
