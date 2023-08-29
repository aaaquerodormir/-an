using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public Sprite profile;
    public string speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    private DialogoControl dc;

    private void Start()
    {
        dc = FindObjectOfType<DialogoControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if(hit != null)
        {
            dc.Speech(profile, speechTxt, actorName);
        }
    }
}
