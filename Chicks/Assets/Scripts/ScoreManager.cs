using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int score;
	public int winScore;
	public Text scoreText;
	public Text winText;
	public Text pauseText;
	bool isPaused;
	public GameObject chickCountScript;

	void Awake () {
		Time.timeScale = 1;
	}
	// Use this for initialization
	void Start () {
		winText.GetComponent<Text>().enabled = false;
		pauseText.GetComponent<Text>().enabled = false;
		score = 0;
		isPaused = false;
		winScore = chickCountScript.GetComponent<SpawnArrays>().chickenCount;
	}
	
	// Update is called once per frame
	void Update () {
		if (score < 0) {
			score = 0;
		}
		if (winScore == score) {
			print("Won");
			winText.GetComponent<Text>().enabled = true;
			Time.timeScale = 0;
		}
		if (isPaused == false) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				pauseText.GetComponent<Text>().enabled = true;
				Time.timeScale = 0;
				isPaused = true;
			}
		}
		else if (isPaused == true) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Time.timeScale = 1;
				pauseText.GetComponent<Text>().enabled = false;
				isPaused = false;
			}
			else if (Input.GetKeyDown(KeyCode.Tab)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(1);
			}
			else if (Input.GetKeyDown(KeyCode.Space)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}
	}
	public void AddPoints(int scoreToAdd) {
		score += scoreToAdd;
	}
	public void Reset() {
		score = 0;
	}
}
