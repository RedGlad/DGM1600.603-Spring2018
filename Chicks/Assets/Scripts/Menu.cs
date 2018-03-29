using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public int levelToLoad;

	// Use this for loading levels.
	public void LoadLevel () {
		SceneManager.LoadScene(levelToLoad);
	}
	
	// Use this to quit.
	public void LevelExit() {
		Application.Quit();
	}
}
