using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StunBullet : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public FadeComponent fade;
    public float stunDuration = 3f; // Duração do atordoamento.
    public float stunTimer = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 6)
        {
            Destroy(gameObject);
        }



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            Control playerControl = other.gameObject.GetComponent<Control>();
            if (playerHealth != null && playerControl != null)
            {
                playerHealth.TakeDamage(8);
                playerControl.Stun(stunDuration);
                if (playerHealth.health <= 0)
                {
                    PerformPlayerRespawn(other.gameObject); // Chama a função de respawn se o jogador morrer.
                }
                Destroy(gameObject); // Destroi a bala.
            }
        }
    }
    void PerformPlayerRespawn(GameObject player)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

