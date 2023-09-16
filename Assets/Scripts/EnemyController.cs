using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem venomPrefab; // Refer�ncia ao prefab do veneno
    private Transform venomSpawnPoint; // Ponto onde o veneno ser� criado
    public float venomInterval = 2f; // Intervalo entre cada lan�amento de veneno
    private float timer = 0f;
    public float venomDuration = 0.5f; // Tempo que o veneno permanece ativo
    private bool isVenomActive = true;
    private ParticleSystem activeVenom; // Refer�ncia ao Particle System ativo

    private void Start()
    {
        venomSpawnPoint = transform.Find("VenomSpawnPoint"); // Encontre o ponto onde o veneno ser� criado
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= venomInterval)
        {
            LaunchVenom();
            timer = 0f; // Resetar o temporizador
        }
    }

    private void LaunchVenom()
    {
        if (isVenomActive)
        {
            if (activeVenom != null)
            {
                // Pause o Particle System ativo
                activeVenom.Pause();

                // Desative o veneno por 5 segundos antes de reativ�-lo
                StartCoroutine(DeactivateAndReactivateVenom());
            }
            else
            {
                // Crie o Particle System se n�o existir
                activeVenom = Instantiate(venomPrefab, venomSpawnPoint.position, Quaternion.identity);
                activeVenom.Pause();
            }
        }
    }

    private IEnumerator DeactivateAndReactivateVenom()
    {
        isVenomActive = false;

        yield return new WaitForSeconds(5f); // Tempo de desativa��o do veneno

        // Garanta que o objeto do Particle System ainda existe antes de tentar reativ�-lo
        if (activeVenom != null)
        {
            isVenomActive = true;
            activeVenom.Play();
        }
    }
}
