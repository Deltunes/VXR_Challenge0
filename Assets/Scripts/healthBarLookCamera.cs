using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarLookCamera : MonoBehaviour
{
    [SerializeField] Camera cam;

    void Start()
    {
        transform.LookAt(transform.position - (cam.transform.position - transform.position));
    }

}
