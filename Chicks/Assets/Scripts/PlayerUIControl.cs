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
		// Make sure game does not start frozen or paused
		Time.timeScale = 1;
	}
	void Start () {
		// Initialize UI components
		pauseText.gameObject.SetActive(false);
		deathText.gameObject.SetActive(false);
		winText.gameObject.SetActive(false);
		textPanel.SetActive(false);
		isPaused = false;
		isDead = false;
		isWon = false;

		// Initialize variables
		currentHealth = maxHealth;
		hpBar.maxValue = maxHealth;
		score = 0;
		// Make the score needed to win equal to the amount of chickens being spawned
		winScore = chickCountScript.GetComponent<SpawnArrays>().chickenCount;
	}
	void Update () {
		// Prevent variables from being out of range
		if (score < 0) {
			score = 0;
		}
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		// Update all variable displays (except ammo, which is handled by the Shoot class)
		hp.text = "HP: " + currentHealth.ToString() + "/" + maxHealth.ToString();
		hpBar.value = currentHealth;
		scoreText.text = score.ToString() + "/" + winScore.ToString();

		// Trigger loss scenario
		if (currentHealth <= 0) {
			currentHealth = 0;
			Time.timeScale = 0;
			deathText.gameObject.SetActive(true);
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
			winText.gameObject.SetActive(true);
			textPanel.SetActive(true);
			isWon = true;
			// Press Space to return to Main Menu
			if (Input.GetKeyDown(KeyCode.Space)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}

		// Trigger Pause Menu
		if (isPaused == false && isDead == false && isWon == false) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				textPanel.SetActive(true);
				pauseText.gameObject.SetActive(true);
				Time.timeScale = 0;
				isPaused = true;
			}
		}
		// De-trigger Pause Menu
		else if (isPaused == true) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Time.timeScale = 1;
				pauseText.gameObject.SetActive(false);
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
		// Damage player using amount from object calling script (WolfAI)
		currentHealth -= amount;
	}
	public void AddPoints(int scoreToAdd) {
		// Add points using amount from object calling script (ChickAI)
		score += scoreToAdd;
	}
}
