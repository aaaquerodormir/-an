using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
 
    [SerializeField] public int lives;
    //private Image healthBar;


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
                Destroy(gameObject);
            }
            
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
