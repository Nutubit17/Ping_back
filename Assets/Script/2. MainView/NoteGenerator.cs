using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject Player;

    SpriteRenderer renderer_pri;


    Vector3 point;
    public Vector3 directVector;


    [SerializeField]
    Vector3 startPoint;

    [SerializeField]
    Vector3 endPoint;

    [SerializeField]
     public float speed;



    bool isNoteStart;

    // Start is called before the first frame update
    void Start()
    {
        renderer_pri = GetComponent<SpriteRenderer>();
        isNoteStart = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (isNoteStart)
        {
            NoteStart();
            isNoteStart = false;
        }

        
        transform.position += directVector * Time.deltaTime * speed;


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, startPoint.x, endPoint.x), Mathf.Clamp(transform.position.y, startPoint.y, endPoint.y), 0);


        if(transform.position.x == startPoint.x || transform.position.x == endPoint.x || transform.position.y ==startPoint.y || transform.position.y == endPoint.y)
        {
            directVector = new Vector3(0, 0, 0);
        }

    }

    void NoteStart()
    {

        transform.position = Player.transform.position;
        
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y, -Camera.main.transform.position.z));

        renderer_pri.color = new Color(255, 255, 255, 255);

        directVector = new Vector3(point.x - transform.position.x, point.y - transform.position.y, 0).normalized;


    }


    
    IEnumerator SetNoteStart()
    {

        yield return new WaitForSeconds(0.00f);


        isNoteStart = !isNoteStart;
        

        

    }


    public void blast(Vector3 pos)
    {
        transform.position = pos;
        gameObject.SetActive(false);

    }



}




