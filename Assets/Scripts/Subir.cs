using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subir : MonoBehaviour
{
   public float startY;            // Posição Y onde a plataforma começa a subir.
    public float targetY1;          // Primeira posição Y alvo (subida).
    public float speed = 2.0f;      // Velocidade de movimento da plataforma.

    private Vector3 targetPosition;
    private bool movingToTarget1 = true;

    private void Start()
    {
        targetPosition = new Vector3(transform.position.x, startY, transform.position.z);
    }

    private void Update()
    {
        // Move a plataforma em direção ao ponto alvo.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Verifica se a plataforma chegou ao ponto alvo.
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Define o próximo ponto alvo com base na direção do movimento.
            if (movingToTarget1)
            {
                targetPosition.y = targetY1;
            }
        }
    }
}
