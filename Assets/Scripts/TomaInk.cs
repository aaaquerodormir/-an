using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomaInk : MonoBehaviour
{
    public InkSplash inksplash;
    public BoxCollider2D box2D;

    private void Start()
    {
        box2D = GetComponent <BoxCollider2D>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("TiroPolvo"))
        {
            inksplash.DoInk();
        }
    }
}
