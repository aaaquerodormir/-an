using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public ParticleSystem venomPrefab; // Referência ao prefab do veneno
    private Transform venomSpawnPoint; // Ponto onde o veneno será criado
    public float venomInterval = 2f; // Intervalo entre cada lançamento de veneno
    public float venomDuration = 0.5f; // Tempo que o veneno permanece ativo
    private bool isVenomActive = false;
    public ParticleSystem activeVenom; // Referência ao Particle System ativo

    private void Start()
    {
        venomSpawnPoint = transform.Find("VenomSpawnPoint"); // Encontre o ponto onde o veneno será criado
        LaunchVenom();
    }

    private void Update()
    {
        
    }

    private void LaunchVenom()
    {
        if (isVenomActive == true)
        {
            if (activeVenom != null)
            {
                // Pause o Particle System ativo
                //activeVenom.Pause();

                // Desative o veneno por 5 segundos antes de reativá-lo
                StartCoroutine(DeactivateAndReactivateVenom());
            }
            else
            {
                // Crie o Particle System se não existir
                activeVenom = Instantiate(venomPrefab, venomSpawnPoint.position, Quaternion.identity);
                //activeVenom.Pause();
            }
        }
    }

    private IEnumerator DeactivateAndReactivateVenom()
    {
        while (true)
        {
            isVenomActive = true;// Tempo de desativação do veneno
            
            activeVenom.Play();
            yield return new WaitForSeconds(5f);
            isVenomActive = false;
            yield return new WaitForSeconds(4f);


            //// Garanta que o objeto do Particle System ainda existe antes de tentar reativá-lo
            if (activeVenom != null)
            {
                isVenomActive = true;
                activeVenom.Play();
                print("teste");
            }
        }
    }
}
