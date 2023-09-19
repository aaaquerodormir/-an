using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placas : MonoBehaviour
{

    public SpriteRenderer sprite;



    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite.enabled = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite.enabled = false;
        }
        
    }
}
