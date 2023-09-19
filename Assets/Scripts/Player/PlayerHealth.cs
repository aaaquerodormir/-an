using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;    
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Heal(float amount)
    {
        health += amount;
        // Certifique-se de que a sa�de n�o ultrapasse o m�ximo
        health = Mathf.Min(health, maxHealth);
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            PerformPlayerRespawn(gameObject);
            Destroy(gameObject);
        }
    }
    void PerformPlayerRespawn(GameObject player)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
