using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public const int maxHealth = 10;
	public int currentHealth = maxHealth;
	public Text hp;
	public Text maxHp;
	public Slider hpBar;
	public Text deathText;
	bool dead;
	
	void Start () {
		deathText.GetComponent<Text>().enabled = false;
	}
	void Update () {
		hp.text = currentHealth.ToString();
		maxHp.text = maxHealth.ToString();
		if (currentHealth >= maxHealth) {
			currentHealth = maxHealth;
		}
		hpBar.value = currentHealth;
		if (dead == true) {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;
		if (currentHealth <= 0) {
			currentHealth = 0;
			print("Game Over");
			Time.timeScale = 0;
			deathText.GetComponent<Text>().enabled = true;
			dead = true;
		}
	}
}
