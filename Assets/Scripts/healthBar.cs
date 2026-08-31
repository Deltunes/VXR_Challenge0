using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateHealth(float currHealth, float maxHealth)
    {
        slider.value = currHealth / maxHealth;
    }
}
