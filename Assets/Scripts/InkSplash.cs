using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSplash : MonoBehaviour
{

    public GameObject FadeObj;
    public float timeInk;
   

    public void DoInk()
    {
        StartCoroutine(Blink());

    }
    
    private IEnumerator Blink()
    {
        FadeObj.SetActive(true);

        yield return new WaitForSeconds(3f);

        FadeObj.SetActive(false);

    }
}
