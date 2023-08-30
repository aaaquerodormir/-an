using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Animator anima;
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private void Update()
    {
     if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            anima.SetBool("Fire", true);
        }
     else
        {
            anima.SetBool("Fire", false);
        }
    }
}

