using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public int healingAmount = 8; // Ajuste a quantidade de cura conforme necess�rio

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifique se o objeto que colidiu � o jogador
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healingAmount); // Chame o m�todo de cura do jogador
                Destroy(gameObject); // Destrua a po��o ap�s o uso  
            }
        }
    }
}
