using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState{ PLAY, GAME_OVER };

public class GameManager : MonoBehaviour {

	public GameObject ringSpawner;

	public GameObject gameOverScreen;

	public Text timerText;

	public GameState currentState;

	public float gameTime;
	public float timer;

	// Use this for initialization
	void Start () {
		ChangeState( GameState.PLAY );
	}
	
	// Update is called once per frame
	void Update () {

		switch( currentState ) {
		case GameState.PLAY:
			timer -= Time.deltaTime;

			timerText.text = ((int)timer).ToString();

			if (timer <= 0f)
				ChangeState (GameState.GAME_OVER);
			break;
		case GameState.GAME_OVER:
			timerText.text = "";
			break;
		}

		if (Input.GetKeyDown (KeyCode.Escape))
			SceneManager.LoadScene ("MainMenu");
	
	}

	public void ChangeState( GameState newState ) {

		switch( newState ) {
		case GameState.PLAY:
			timer = gameTime;
			gameOverScreen.SetActive (false);
			break;
		case GameState.GAME_OVER:
			gameOverScreen.SetActive (true);
			break;
		}

		currentState = newState;
	}
}
