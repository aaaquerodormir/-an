using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem venomPrefab; // Refer�ncia ao prefab do veneno
    private Transform venomSpawnPoint; // Ponto onde o veneno ser� criado
    public float venomInterval = 2f; // Intervalo entre cada lan�amento de veneno
    public float venomDuration = 0.5f; // Tempo que o veneno permanece ativo
    private bool isVenomActive = false;
    public ParticleSystem activeVenom; // Refer�ncia ao Particle System ativo

    private void Start()
    {
        venomSpawnPoint = transform.Find("VenomSpawnPoint"); // Encontre o ponto onde o veneno ser� criado
        LaunchVenom();
    }

    private void Update()
    {

    }

    private void LaunchVenom()
    {
        if (activeVenom == null)
        {
            activeVenom = Instantiate(venomPrefab, venomSpawnPoint.position, Quaternion.identity).GetComponent<ParticleSystem>();
            // Pause o Particle System ativo
            //activeVenom.Pause();

            // Desative o veneno por 5 segundos antes de reativ�-lo
        }
        StartCoroutine(DeactivateAndReactivateVenom());
    }

    private IEnumerator DeactivateAndReactivateVenom()
    {
        while (true)
        {

            //// Garanta que o objeto do Particle System ainda existe antes de tentar reativ�-lo
            if (activeVenom != null)
            {
                isVenomActive = true;
                activeVenom.Play();
                print("teste");
            }
            yield return new WaitForSeconds(activeVenom.main.duration);
            isVenomActive = false;
            float intervalo = 5;
            yield return new WaitForSeconds(intervalo);

        }
    }
}
