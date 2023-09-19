using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveMar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().temChave = true;
            Destroy(this.gameObject);
        }
    }
}
