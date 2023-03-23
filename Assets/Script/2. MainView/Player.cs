using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private GameObject Note;
    
    NoteGenerator noteScript;
    SpriteRenderer noteRenderer;



    [SerializeField]
    GameObject checkPoint;



    Vector3 directVector_Pri;
    float speed_Pri;



    [SerializeField]
    Vector3 startPoint;
    [SerializeField]
    Vector3 endPoint;

    enum mode {stay, drop}

    mode playerMode;

    bool isDelay;
    float delayCheck;
    float delayValue;


    // possession = ºùÀÇ
    // blast      = Æø¹ß

    // Start is called before the first frame update
    void Start()
    {
        Note.SetActive(false);
        noteScript = Note.GetComponent<NoteGenerator>();
        noteRenderer = Note.GetComponent<SpriteRenderer>();


        isDelay = false;
        delayCheck = 0f;
        delayValue = 0.1f;
        
        playerMode = mode.stay;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, startPoint.x, endPoint.x), Mathf.Clamp(transform.position.y, startPoint.y, endPoint.y), 0);

        transform.position += directVector_Pri * Time.deltaTime * speed_Pri;


        #region dropbulb
        if (Input.GetKeyDown(KeyCode.Space) && (playerMode == mode.stay))
        {

            Note.SetActive(true);
            noteScript.StartCoroutine("SetNoteStart");

            checkPoint.transform.position = transform.position;

            playerMode = mode.drop;
            isDelay = true;

        }

        #endregion dropbulb
        
        if (isDelay)
        {
            delayCheck += Time.deltaTime;

            if(delayCheck >= delayValue)
            {
                delayCheck = 0f;
                isDelay = false;
            }
        }
        // isDelay = true ·Î È£Ãâ

        #region possession

        if (((Input.GetKeyDown(KeyCode.Space) && playerMode == mode.drop))&&!isDelay)
        {

            transform.position = Note.transform.position;
            playerMode = mode.stay;
            
            directVector_Pri = noteScript.directVector;
            speed_Pri = noteScript.speed;

            noteRenderer.color = new Color(255, 255, 255, 0);
            
            Note.SetActive(false);
            
        }

        #endregion possession


        if(Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)) // blast
        {
            directVector_Pri = new Vector3(0,0,0);
            speed_Pri = 0f;

            transform.position = checkPoint.transform.position;
            
            
            if(playerMode == mode.drop)
                noteScript.blast(checkPoint.transform.position);



            playerMode = mode.stay;

        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Note"))
        {
            speed_Pri = 0f;
            directVector_Pri = new Vector3(0, 0, 0);

        }
    }

}
