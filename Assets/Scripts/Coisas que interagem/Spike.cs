using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    public float respawnTime = 10f; // Tempo em segundos para o espinho reaparecer.
    public int spikeDamage = 10; // Quantidade de dano causada pelo espinho.

    private bool hasHit = false; // Indica se o espinho acertou algo.
    private float timer = 0f; // Contador de tempo desde o desaparecimento.

    // Vari�vel para armazenar a posi��o inicial.
    private Vector3 initialPosition;

    private Rigidbody2D rb; // Refer�ncia para o Rigidbody2D.

    private void Start()
    {
        // Salva a posi��o inicial ao iniciar o jogo.
        initialPosition = transform.position;

        // Obt�m a refer�ncia para o Rigidbody2D.
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (hasHit)
        {
            timer += Time.deltaTime;
            if (timer >= respawnTime)
            {
                RespawnSpike();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasHit)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
            {
                // Colidiu com o ch�o ou jogador, fa�a algo (por exemplo, causar dano ao jogador).
                if (collision.gameObject.CompareTag("Player"))
                {
                    PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                    if (playerHealth != null)
                    {
                        // Causar dano ao jogador.
                        playerHealth.health -= spikeDamage;
                        if (playerHealth.health <= 0)
                        {
                            PerformPlayerRespawn(collision.gameObject); // Chama a fun��o de respawn se o jogador morrer.
                        }
                    }
                }

                // Marque que o espinho acertou algo e desative-o.
                hasHit = true;
                rb.velocity = Vector2.zero; // Define a velocidade do espinho como zero.
                gameObject.GetComponent<Collider2D>().enabled = false; // Desativa o collider para evitar detec��o adicional.
                GetComponent<SpriteRenderer>().enabled = false; // Oculta o sprite do espinho.
            }
        }
    }

    private void RespawnSpike()
    {
        // Quando o tempo de respawn � atingido, reative o espinho e resete as vari�veis.
        hasHit = false;
        timer = 0f;
        rb.velocity = Vector2.zero; // Define a velocidade do espinho como zero.
        gameObject.GetComponent<Collider2D>().enabled = true; // Reativa o collider.
        GetComponent<SpriteRenderer>().enabled = true; // Mostra o sprite do espinho.

        // Defina a posi��o de respawn aqui (por exemplo, para a posi��o inicial).
        transform.position = initialPosition; // Substitua "initialPosition" pela posi��o desejada.
    }

    void PerformPlayerRespawn(GameObject player)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}