using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTurnBased : MonoBehaviour
{
    [SerializeField] healthBar enemyHealthBar;

    public float maxHealth;
    public float currHealth;

    private void Start()
    {
        currHealth = maxHealth;
        enemyHealthBar.UpdateHealth(currHealth, maxHealth);
    }

    public void damageEnemy(float damageAmount, string damageType)
    {
        currHealth = currHealth - damageAmount;
        enemyHealthBar.UpdateHealth(currHealth, maxHealth);
    }
}
