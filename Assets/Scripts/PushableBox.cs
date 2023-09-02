using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LimiteEsquerda") || collision.gameObject.CompareTag("LimiteDireita"))
        {
            // Pare o movimento da caixa ao atingir um limite.
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
