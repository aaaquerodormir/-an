using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private void Update()
    {
     if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}

