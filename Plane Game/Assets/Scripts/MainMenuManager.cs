using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public bool invertedControls;

	// Use this for initialization
	void Start () {
		invertedControls = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene( string sceneName ) {
		if (sceneName == "JoystickControl" && invertedControls) {
			sceneName += "Inverted";
		}

		SceneManager.LoadScene(sceneName);
	}



	public void ToggleInverted()
	{
		invertedControls = !invertedControls;
	}
}
