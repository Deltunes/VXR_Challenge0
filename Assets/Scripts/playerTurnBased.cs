using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTurnBased : MonoBehaviour
{
    [SerializeField] healthBar playerHealthBar;
    [SerializeField] TPBar playerTPBar;
    public float maxHealth;
    public float currHealth;
    public float maxTP;
    public float currTP;
    public bool defending = false;

    private void Start()
    {
        currHealth = maxHealth;
        currTP = maxTP / 2.0f;
        playerHealthBar.UpdateHealth(currHealth, maxHealth);
        playerTPBar.UpdateTP(currTP, maxTP);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            damagePlayer(5.0f, "standard");
        }
    }

    public void damagePlayer(float damageAmount, string damageType)
    {
        if (defending)
        {
            damageAmount = damageAmount / 2;
        }
        currHealth = currHealth - damageAmount;
        playerHealthBar.UpdateHealth(currHealth, maxHealth);
    }

    public void healPlayer(float healAmount)
    {
        currHealth = currHealth + healAmount;
        playerHealthBar.UpdateHealth(currHealth, maxHealth);
    }

    public void TPIncrease(float TPAmount)
    {
        currTP = currTP + TPAmount;
        playerTPBar.UpdateTP(currTP, maxTP);
    }

    public void TPDecrease(float TPAmount)
    {
        currTP = currTP - TPAmount;
        if (currTP < 0)
        {
            currTP = 0;
        }
        playerTPBar.UpdateTP(currTP, maxTP);
    }
}
