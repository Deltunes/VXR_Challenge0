using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone_detector : MonoBehaviour
{
    public int zoneno;
    public Camera cam;
    public Transform cam_pos;

    float lerpSpeed;
    bool approachPos;

    private void Start()
    {
        approachPos = false;
        lerpSpeed = 8f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player entered zone " + zoneno + "!");
            lerpSpeed = 8f;
            approachPos = true;
        }
    }

    private void Update()
    {
        if (approachPos)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, cam_pos.position, lerpSpeed * Time.deltaTime);
            lerpSpeed = lerpSpeed * 1.01f;
            if (cam.transform.position == cam_pos.position)
            {
                approachPos = false;
            }
        }
    }
}
