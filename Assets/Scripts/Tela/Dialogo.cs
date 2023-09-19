using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && dc.CanStartSpeech())
        {
            dc.Speech(profile, speechTxt, actorName);
        }
    }

    private void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        dc.UpdatePlayerInRadious(hit != null);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, radious);
    }
}
