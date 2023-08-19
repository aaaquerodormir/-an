using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
   public GameObject bullet;
    public Transform bulletPos;
    
    private float timer;
    private float shootInterval = 2f; // Intervalo de tempo entre os tiros.
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
                shoot();
                timer = 0; // Reseta o timer.
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
