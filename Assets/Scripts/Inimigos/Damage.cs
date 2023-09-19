using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    //public PlayerHealth pHealth;
    public float damage;
    public float restartDelay = 1.0f; // Tempo de atraso em segundos
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //StartCoroutine(Blink());
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                if (playerHealth.health <= 0)
                {
                    Invoke("RestartScene", restartDelay); // Chama a função de reiniciar após o atraso
                }
            }
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //IEnumerator Blink()
    //{
    //    SpriteRenderer renderer = GetComponent<SpriteRenderer>();
    //    for (int i = 0; i < 5; i++)
    //    {
    //        renderer.color = new Color(1, 0, 0);

    //        yield return new WaitForSeconds(0.1f);

    //        renderer.color = new Color(1, 1, 1);
    //    }
    //}
}
