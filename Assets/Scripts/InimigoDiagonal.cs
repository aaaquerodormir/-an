using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoDiagonal : MonoBehaviour
{
    public float speed = 2.0f; // Velocidade de movimento
    public Vector2 moveDirection = new Vector2(1, -1); // Dire��o de movimento (pode ser ajustada no Inspector)
    private Vector3 startPos; // Posi��o inicial

    private void Start()
    {
        startPos = transform.position; // Armazena a posi��o inicial
    }

    private void Update()
    {
        // Calcula o deslocamento baseado na dire��o e velocidade
        Vector2 movement = moveDirection.normalized * speed * Time.deltaTime;

        // Atualiza a posi��o do inimigo
        transform.Translate(movement, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Inverte a dire��o vertical ao colidir com obst�culos
        if (collision.gameObject.CompareTag("Collider"))
        {
            moveDirection.y = -moveDirection.y;
        }
    }

}
