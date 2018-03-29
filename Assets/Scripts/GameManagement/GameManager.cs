using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    LoadingScreen,
    MainMenu
}
public delegate void OnStateChangeHandler();

public class GameManager : MonoSingleton<GameManager> {
   
 
    public event OnStateChangeHandler OnStateChange;
   

    public GameStates GameState { get; private set; }
    // Use this for initialization
    void Start () {
        
    }
	public void LoadScene()
    {

    }

    public void SetGameState(GameStates gameState)
    {
        this.GameState = gameState;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

 
}
