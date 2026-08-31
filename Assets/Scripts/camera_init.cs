using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_init : MonoBehaviour
{
    public Camera cam;
    public Transform init_pos;

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = init_pos.position;
    }
}
