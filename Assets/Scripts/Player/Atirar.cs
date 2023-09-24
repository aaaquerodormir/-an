using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Animator anima;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private float Delay = 0.2f;
    private bool CanFire = true;

    private void Update()
    {
     if (Input.GetButtonDown("Fire2") && CanFire)
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            anima.SetBool("Fire", true);
            StartCoroutine(atirandocd());
        }
     else
        {
            anima.SetBool("Fire", false);
        }
    }
    IEnumerator atirandocd()
    {
        CanFire = false;
        yield return new WaitForSeconds(Delay);
        CanFire = true;
    }
}

