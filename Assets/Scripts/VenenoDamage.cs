using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenenoDamage : MonoBehaviour
{
    public float danoPorSegundo = 1f;
    private PlayerHealth playerHealth;
    public float damageInterval = 1f; // Intervalo de dano (1 segundo, por padrão)
    private float timer = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidindo é o jogador
        if (other.CompareTag("Player"))
        {
            // Obtém uma referência ao script de vida do jogador
            playerHealth = other.GetComponent<PlayerHealth>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Se o jogador sair da área do veneno, defina a referência do script de vida como nula
        if (other.CompareTag("Player"))
        {
            playerHealth = null;
        }
    }

    private void Update()
    {
        // Verifica se o jogador está dentro da área do veneno e se o script de vida do jogador está definido
        if (playerHealth != null)
        {
            timer += Time.deltaTime;

            // Verifica se é hora de aplicar dano com base no intervalo de tempo
            if (timer >= damageInterval)
            {
                // Aplica o dano por segundo ao jogador
                playerHealth.TakeDamage(danoPorSegundo * damageInterval);
                timer = 0f; // Resetar o temporizador
            }
        }
    }
}
