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
            lerpSpeed = 10f;
            approachPos = true;
        }
    }

    private void FixedUpdate()
    {
        if (approachPos)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, cam_pos.position, lerpSpeed * Time.deltaTime);
            lerpSpeed = lerpSpeed * 1.04f;
            if (cam.transform.position == cam_pos.position)
            {
                approachPos = false;
            }
        }
    }
}
