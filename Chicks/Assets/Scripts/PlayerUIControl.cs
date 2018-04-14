using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIControl : MonoBehaviour {

	public int maxHealth, currentHealth, score, winScore;
	public Text hp, deathText, scoreText, winText, pauseText;
	public GameObject textPanel;
	public Slider hpBar;
	bool isDead, isPaused, isWon;
	public GameObject chickCountScript;
	
	void Awake () {
		// Make sure game is still running
		Time.timeScale = 1;
	}
	void Start () {
		// Initialize UI components and variables
		winText.GetComponent<Text>().enabled = false;
		pauseText.GetComponent<Text>().enabled = false;
		deathText.GetComponent<Text>().enabled = false;
		textPanel.SetActive(false);

		currentHealth = maxHealth;
		hpBar.maxValue = maxHealth;
		// Pull number of spawned chickens to be number of chickens needed to win.
		winScore = chickCountScript.GetComponent<SpawnArrays>().chickenCount;
		score = 0;

		isPaused = false;
		isDead = false;
		isWon = false;
	}
	void Update () {
		// Prevent variables from being out of range
		if (score < 0) {
			score = 0;
		}
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		// Update all variable displays (except ammo, handled by Shoot script)
		hp.text = "HP: " + currentHealth.ToString() + "/" + maxHealth.ToString();
		hpBar.value = currentHealth;
		scoreText.text = "Chickens Caught: " + score.ToString() + "/" + winScore.ToString();

		// Trigger loss scenario
		if (currentHealth <= 0) {
			currentHealth = 0;
			Time.timeScale = 0;
			deathText.GetComponent<Text>().enabled = true;
			textPanel.SetActive(true);
			isDead = true;
			// Press Space to return to Main Menu
			if (Input.GetKeyDown(KeyCode.Space)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}
		// Trigger win scenario
		if (score >= winScore) {
			score = winScore;
			Time.timeScale = 0;
			winText.GetComponent<Text>().enabled = true;
			textPanel.SetActive(true);
			isWon = true;
			// Press Space to return to Main Menu
			if (Input.GetKeyDown(KeyCode.Space)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}

		// Trigger Pause menu

		if (isPaused == false && isDead == false && isWon == false) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				textPanel.SetActive(true);
				pauseText.GetComponent<Text>().enabled = true;
				Time.timeScale = 0;
				isPaused = true;
			}
		}
		else if (isPaused == true) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Time.timeScale = 1;
				pauseText.GetComponent<Text>().enabled = false;
				textPanel.SetActive(false);
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
	public void TakeDamage(int amount) {
		// Damage player using amount from object calling script
		currentHealth -= amount;
	}
	public void AddPoints(int scoreToAdd) {
		// Add points using amount from object calling script
		score += scoreToAdd;
	}
}
