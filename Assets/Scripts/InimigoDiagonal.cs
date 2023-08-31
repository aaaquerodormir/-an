using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoDiagonal : MonoBehaviour
{
    public float speed = 2.0f; // Velocidade de movimento
    public Vector2 moveDirection = new Vector2(1, -1); // Direção de movimento (pode ser ajustada no Inspector)
    private Vector3 startPos; // Posição inicial

    private void Start()
    {
        startPos = transform.position; // Armazena a posição inicial
    }

    private void Update()
    {
        // Calcula o deslocamento baseado na direção e velocidade
        Vector2 movement = moveDirection.normalized * speed * Time.deltaTime;

        // Atualiza a posição do inimigo
        transform.Translate(movement, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Inverte a direção vertical ao colidir com obstáculos
        if (collision.gameObject.CompareTag("Collider"))
        {
            moveDirection.y = -moveDirection.y;
        }
    }

}
