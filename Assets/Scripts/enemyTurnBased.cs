using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            damageEnemy(5.0f, "standard");
        }
    }

    public void damageEnemy(float damageAmount, string damageType)
    {
        currHealth = currHealth - damageAmount;
        enemyHealthBar.UpdateHealth(currHealth, maxHealth);
    }
}
