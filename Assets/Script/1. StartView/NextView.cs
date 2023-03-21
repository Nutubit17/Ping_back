using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextView : MonoBehaviour
{
    
    [SerializeField]
    GameObject nextView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            nextView.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
