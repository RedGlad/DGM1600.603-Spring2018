using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public int levelToLoad;

	public void LoadLevel () {
		// Start game
		SceneManager.LoadScene(levelToLoad);
	}
	public void LevelExit() {
		// Quit game
		Application.Quit();
	}
}
