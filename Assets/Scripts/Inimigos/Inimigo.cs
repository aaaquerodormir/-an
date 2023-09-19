using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float velocidade = 2f; // velocidade do inimigo
    public float distanciaDePerseguicao = 5f; // distância para o inimigo começar a perseguir
    private Transform jogador;
    private Rigidbody2D rb;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
         // Vê certinho a distância para o player
        float distanciaParaJogadorX = Mathf.Abs(transform.position.x - jogador.position.x);

         // Se tiver dentro da distância necessária
        if (distanciaParaJogadorX < distanciaDePerseguicao)
        {
            // calcula a direção para o player no eixo X
            float direcaoX = (jogador.position.x - transform.position.x);

            // Move o inimigo apenas no eixo X
            rb.velocity = new Vector2(direcaoX > 0 ? velocidade : -velocidade, rb.velocity.y);
        }
        else
        {
            // Para o movimento se o jogador estiver fora da distância de perseguição
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}
