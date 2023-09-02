using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjetilScript : MonoBehaviour
{
    public float forcaTiro = 10f;
    public float tempoDeVida = 5.5f; // Tempo de vida da bala.

    private float tempoVivo = 0f; // Contador de tempo desde o disparo.

    void Start()
    {
        Atirar();
    }

    void Update()
    {
        tempoVivo += Time.deltaTime;

        // Verifique se a bala deve desaparecer.
        if (tempoVivo >= tempoDeVida)
        {
            Destroy(gameObject);
        }
    }

    void Atirar()
    {
        // Aplica uma força para atirar a bala.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * forcaTiro, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.health -= 8; // Reduz a saúde do jogador em 4 quando atingido pela bala.

                if (playerHealth.health <= 0)
                {
                    PerformPlayerRespawn(other.gameObject);
                }
            }
        }
    }

    void PerformPlayerRespawn(GameObject player)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}