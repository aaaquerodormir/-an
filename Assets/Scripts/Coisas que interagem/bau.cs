using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bau : MonoBehaviour
{
    public string level2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<Control>().temChave == true && other.gameObject.tag == "Player")
            {
                MyLoading.LoadLevel(level2);
                Debug.Log("Abrir Bau");
            }
            else
            {
                Debug.Log("Voce precisa coletar a chave!");
            }
        }
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //}
}
