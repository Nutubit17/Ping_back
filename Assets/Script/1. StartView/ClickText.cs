using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTest : MonoBehaviour
{
    float Delay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //StartCoroutine("Opecity", Delay, gameObject);

    }

    IEnumerator Opecity(float delay, GameObject text)
    {

        yield return new WaitForSeconds(delay);

        if (gameObject.activeSelf)
        {
            text.SetActive(false);
        }
        else
        {
            text.SetActive(true);
        }

    }



}
