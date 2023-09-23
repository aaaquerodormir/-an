using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    [SerializeField] private int lives;
    [SerializeField] private GameObject chavePrefab;

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            StartCoroutine(Blink());

            lives--;
            if (lives < 1)
            {
                DropChave();
                Destroy(gameObject);
            }

        }

    }

    private void DropChave()
    {
        if (chavePrefab != null)
        {
            // Crie uma instância da chave no mesmo local que o boss
            Instantiate(chavePrefab, transform.position, Quaternion.identity);
        }
    }

        IEnumerator Blink()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 5; i++)
        {
            renderer.color = new Color(1, 0, 0);

            yield return new WaitForSeconds(0.1f);

            renderer.color = new Color(1, 1, 1);
        }
    }
}