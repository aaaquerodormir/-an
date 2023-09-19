using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Opcoes;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controles()
    {
        SceneManager.LoadScene("Opcoes");
    }
    
    public void SairControles()
    {
        SceneManager.LoadScene("Menu");
    }


    //public void PlayGame()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
    public void PlayGame()
    {
       MyLoading.LoadLevel("level");
    }

}
