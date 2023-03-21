using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSpown : MonoBehaviour
{

    [SerializeField]
    GameObject block;

    [SerializeField]
    GameObject bundle;

    GameObject[] Bundles;
    GameObject[,] blocks;
    
    [SerializeField]
    float b_width = 1f;

    [SerializeField]
    float b_height = 1f;

    // Start is called before the first frame update
    void Start()
    {
        blocks = new GameObject[(int)b_width, (int)b_height];
        Bundles = new GameObject[(int)b_width];

        for(int i = 0; i<b_width; i++)
        {
            Bundles[i] = Instantiate(bundle, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            Bundles[i].name = "Bundle " + i;

            for(int j = 0; j<b_height; j++)
            {
                block.name = "Block " + i + " " + j; 


                blocks[i, j] = Instantiate(block, gameObject.transform.localPosition + new Vector3((float)i - ((b_width-1) / 2), (float)j - ((b_height-1) / 2), 0), Quaternion.identity, Bundles[i].transform);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
