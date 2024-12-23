using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stats : MonoBehaviour
{
    public int startHealth = 100;
    public int currHealth;
    public Text HealthText;

    void Start()
    {
        currHealth = startHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        if (currHealth <= 0)
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
        HealthText.text = "HP: " + currHealth;
    }

    void PlayerDie()
    {
        Debug.Log("Player Die");
    }
}
