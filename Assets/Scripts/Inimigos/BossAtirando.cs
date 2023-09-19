using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtirando : MonoBehaviour
{
    public GameObject bullet; // prefab bala padrão
    public GameObject stunBullet; // prefab bala stun
    public Transform bulletPos; // posição da bala

    private float timer; //controlar o tempo dos tiros
    private float shootInterval = 5f; // tempo p/ atirar
    private int normalShotsFired = 0; // tiros normais dados
    private int shotsUntilStun = 6; // tiros para stun
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {
            timer += Time.deltaTime;

            if (timer >= shootInterval) 
            {
                Shoot();
                timer = 0; // reseta o timer para atirar
                normalShotsFired++; // aumenta o contador de tiros

                if(normalShotsFired >= shotsUntilStun)
                {
                    ShootStunBullet();
                    normalShotsFired = 0; // depois do tiro com stun, reseta o contador
                }
            }
            // verifica posição do player em relação ao boss
            if (player.transform.position.x > transform.position.x)
            {
                // Player a direita, vira para a direita
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                // Player a esquerda, vira para a esquerda
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private void ShootStunBullet()
    {
        Instantiate(stunBullet, bulletPos.position, Quaternion.identity);
    }
}
