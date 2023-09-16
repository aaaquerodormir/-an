using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float amount)
    {
        health += amount;
        // Certifique-se de que a sa�de n�o ultrapasse o m�ximo
        health = Mathf.Min(health, maxHealth);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
