using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TPBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void UpdateTP(float currTP, float maxTP)
    {
        slider.value = currTP / maxTP;
    }
}
