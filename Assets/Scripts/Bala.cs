using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D (Collision2D collision)
    {
        Destroy(gameObject);

    }
}
