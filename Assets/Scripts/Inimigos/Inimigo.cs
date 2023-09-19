using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float velocidade = 2f; // velocidade do inimigo
    public float distanciaDePerseguicao = 5f; // dist�ncia para o inimigo come�ar a perseguir
    private Transform jogador;
    private Rigidbody2D rb;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
         // V� certinho a dist�ncia para o player
        float distanciaParaJogadorX = Mathf.Abs(transform.position.x - jogador.position.x);

         // Se tiver dentro da dist�ncia necess�ria
        if (distanciaParaJogadorX < distanciaDePerseguicao)
        {
            // calcula a dire��o para o player no eixo X
            float direcaoX = (jogador.position.x - transform.position.x);

            // Move o inimigo apenas no eixo X
            rb.velocity = new Vector2(direcaoX > 0 ? velocidade : -velocidade, rb.velocity.y);
        }
        else
        {
            // Para o movimento se o jogador estiver fora da dist�ncia de persegui��o
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}
