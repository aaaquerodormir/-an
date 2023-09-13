using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private float shootInterval = 5f; // Intervalo de tempo entre os tiros.
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {
            timer += Time.deltaTime;

            if (timer >= shootInterval)
            {
                Shoot();
                timer = 0; // Reseta o timer.
            }

            // Verifique a posição do jogador em relação ao inimigo
            if (player.transform.position.x > transform.position.x)
            {
                // Jogador está à direita, rotacione para a direita
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                // Jogador está à esquerda, rotacione para a esquerda
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


}
