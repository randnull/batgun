using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float startHealth = 100f;
    public float currHealth;
    public Text HealthText;

    void Start()
    {
        currHealth = startHealth;
        UpdateHealthText();
    }

	void Update() {
		if (this.gameObject.transform.position.y < -5f) {
			PlayerDie();
		}
	}

    public void TakeDamage(float damage)
    {
        if (currHealth <= 0.01f)
        {
            PlayerDie();
        }
        else
        {
            currHealth -= damage;
        }

        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        HealthText.text = "HP: " + (int)currHealth;
    }

    public void PlayerDie()
    {
		Cursor.lockState = CursorLockMode.None;
       	Cursor.visible = true;
        Debug.Log("Player Die");
		SceneManager.LoadScene("GameOver");
    }
}
