using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float max_HP;
    public Transform player;

    Rigidbody rb;
    float hitForce;

    private float curr_HP;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitForce = 400.0f;
        max_HP = 100f;
        curr_HP = max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            decrement_HP(5.0f);
        }
        if (curr_HP <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void decrement_HP(float amount)
    {
        curr_HP -= amount;
        Vector3 hitDir = (transform.position - player.position).normalized;
        rb.AddForce(hitDir * hitForce);
    }
}
