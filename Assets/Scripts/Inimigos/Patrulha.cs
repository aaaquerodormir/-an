using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulha : MonoBehaviour
{
    bool right = true;
    public float maxr;
    public float maxl;
  

    // Update is called once per frame
    void Update()
    {
        


        if (right == true)
        {
            transform.position += new Vector3(0.001f, 0, 0);
            if (transform.position.x > maxr)
            {
                right = false;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            transform.position -= new Vector3(0.001f, 0, 0);
            if (transform.position.x < maxl)
            {
                right = true;
                transform.rotation = Quaternion.identity;
            }
        }
    }
}