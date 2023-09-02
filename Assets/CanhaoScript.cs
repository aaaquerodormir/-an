using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoScript : MonoBehaviour
{
    public GameObject projetilPrefab; // Prefab do projetil.
    public float forcaTiro = 10f; // Força do tiro.
    public float intervaloDeTiro = 8f; // Intervalo entre os tiros em segundos.

    private float tempoDesdeUltimoTiro = 0f;

    private void Update()
    {
        tempoDesdeUltimoTiro += Time.deltaTime;

        if (tempoDesdeUltimoTiro >= intervaloDeTiro)
        {
            Atirar();
            tempoDesdeUltimoTiro = 0f;
        }
    }

    void Atirar()
    {
        // Crie um projetil na posição e rotação do canhão.
        GameObject projetil = Instantiate(projetilPrefab, transform.position, transform.rotation);

        // Aplique uma força ao projetil para fazê-lo mover para frente.
        Rigidbody2D rb = projetil.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * forcaTiro, ForceMode2D.Impulse);

        // Destrua o projetil após 10 segundos.
        Destroy(projetil, 10f);
    }
}

