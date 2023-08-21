using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    //private Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        health -= amount; // Reduz a vida atual pelo valor do dano.

        if (health <= 0)
        {
            Die(); // Chama uma fun��o para lidar com a morte do inimigo.
        }
    }

    void Die()
    {
        // L�gica para a morte do inimigo, como tocar uma anima��o, reproduzir som, etc.
        Destroy(gameObject); // Destroi o objeto do inimigo.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile")) // Verifica a tag do objeto colidido.
        {
            // Aplica dano ao inimigo quando o proj�til do jogador colidir.
            PlayerProjectile playerProjectile = collision.gameObject.GetComponent<PlayerProjectile>();
            if (playerProjectile != null)
            {
                TakeDamage(playerProjectile.damageAmount); // Aplica dano ao inimigo.
                Destroy(collision.gameObject); // Destroi o proj�til do jogador.
            }
        }
    }
}
