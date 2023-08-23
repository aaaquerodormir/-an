using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
 
    [SerializeField] public int lives;
    //private Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {


            lives--;
            if (lives < 1)
            {
                Destroy(gameObject);
            }
            
        }
        
    }
}
