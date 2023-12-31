using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VenenoDamage : MonoBehaviour
{
    public float danoPorSegundo = 1f;
    private PlayerHealth playerHealth;
    public float damageInterval = 1f; // Intervalo de dano (1 segundo, por padr�o)
    private float timer = 0f;
    public bool isVenomActive = false;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidindo � o jogador
        if (other.CompareTag("Player"))
        {
            // Obt�m uma refer�ncia ao script de vida do jogador
            playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth.health <= 0)
            {
                PerformPlayerRespawn(other.gameObject); // Chama a fun��o de respawn se o jogador morrer.
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Se o jogador sair da �rea do veneno, defina a refer�ncia do script de vida como nula
        if (other.CompareTag("Player"))
        {
            timer = 0;
            playerHealth = null;
        }
        

    }

    private void Update()
    {
        // Verifica se o jogador est� dentro da �rea do veneno e se o script de vida do jogador est� definido
        if (playerHealth != null && isVenomActive)
        {
            timer += Time.deltaTime;

            // Verifica se � hora de aplicar dano com base no intervalo de tempo
            if (timer >= damageInterval)
            {
                // Aplica o dano por segundo ao jogador
                playerHealth.TakeDamage(danoPorSegundo * damageInterval);
                timer = 0f; // Resetar o temporizador
            }
          
        }

   
    }
    void PerformPlayerRespawn(GameObject player)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
