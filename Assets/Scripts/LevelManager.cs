using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
     //public GameObject respawn;
    public GameObject playerprefab;
    //GameObject playerinstance;

    // Use this for initialization
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //void CreatePlayer()
    //{
    //    playerinstance = Instantiate(playerprefab, respawn.transform.position, Quaternion.identity);
    //}
    /// <summary>
    /// Aplica pouco dano
    /// </summary>
    
}