using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class turnBasedBattle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI turnIndicator;
    [SerializeField] playerTurnBased player;
    [SerializeField] enemyTurnBased enemy;
    [SerializeField] float enemyTurnDuration;
    [SerializeField] VerticalLayoutGroup skillButtons;
    [SerializeField] float fireTPCost = 30.0f;
    [SerializeField] float electricTPCost = 50.0f;
    [SerializeField] float healTPCost = 70.0f;

    private int turnState;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        turnState = 0;
    }

    public void enemyFight()
    {
        if (turnState == 1)
        {
            player.damagePlayer(16.0f, "standard");
            changeTurn();
        }
    }

    public void playerFight()
    {
        if (turnState == 0)
        {
            enemy.damageEnemy(10.0f, "standard");
            player.TPIncrease(8.0f);
            changeTurn();
        }
    }

    public void playerSkill()
    {
        if (turnState == 0)
        {
            if (skillButtons.gameObject.activeSelf == false)
            {
                skillButtons.gameObject.SetActive(true);
            }
            else
            {
                skillButtons.gameObject.SetActive(false);
            }
        }
    }

    public void playerFire()
    {
        if (turnState == 0)
        {
            if (player.currTP >= fireTPCost)
            {
                enemy.damageEnemy(30.0f, "fire");
                player.TPDecrease(fireTPCost);
                changeTurn();
            }
        }
    }

    public void playerElectric()
    {
        if (turnState == 0)
        {
            if (player.currTP >= electricTPCost)
            {
                enemy.damageEnemy(50.0f, "electric");
                player.TPDecrease(electricTPCost);
                changeTurn();
            }
        }
    }

    public void playerHeal()
    {
        if (turnState == 0)
        {
            if (player.currTP >= healTPCost)
            {
                player.healPlayer(50.0f);
                player.TPDecrease(healTPCost);
                changeTurn();
            }
        }
    }

    public void playerDefend()
    {
        if (turnState == 0)
        {
            player.defending = true;
            player.TPIncrease(30.0f);
            changeTurn();
        }
    }

    private void changeTurn()
    {
        checkDeath();
        if (turnState == 0)
        {
            turnState = 1;
            turnIndicator.text = "Enemy's Turn!";
            skillButtons.gameObject.SetActive(false);
            StartCoroutine(WaitASec());
        }
        else if (turnState == 1)
        {
            turnState = 0;
            turnIndicator.text = "Your Turn!";
        }
    }

    private void checkDeath()
    {
        if (enemy.currHealth <= 0)
        {
            GameManager.battleWinState = 1;
            SceneManager.LoadScene("HUBScene");
        }

        if (player.currHealth <= 0)
        {
            GameManager.battleWinState = 2;
            SceneManager.LoadScene("HUBScene");
        }
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(enemyTurnDuration);
        enemyFight();
    }
}
