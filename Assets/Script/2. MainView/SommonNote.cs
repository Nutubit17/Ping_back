using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SommonNote : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject Note_Prefab;

    [SerializeField] int Note_Num;

    [SerializeField] float NoteDelay;

    GameObject[] Note_Range;



    GameObject Present_Note;
    [SerializeField] Vector3 Present_Note_Rotate;
    [SerializeField] float Present_Note_Speed;






    void Start()
    {
        Note_Range = new GameObject[Note_Num];

        for(int i = 0; i<Note_Num; i++)
        {
            Note_Range[i] = Instantiate(Note_Prefab,gameObject.transform);
            Note_Range[i].name = $"{i}:Note ";
            Note_Range[i].SetActive(false);
        }

        StartCoroutine("SetMove",NoteDelay);

    }

    // Update is called once per 



    GameObject Pooling_Note(GameObject[] arr)
    {
        int i;
        
        for(i = 0; i<arr.Length; i++)
        {
            if (!arr[i].activeSelf)
            {
                arr[i].SetActive(true);
                break;
            }
        }


        return (i!=(arr.Length+1)) ? arr[i] : null;

    }




    NoteMovementFunction NoteCon;
    IEnumerator SetMove(float delay)
    {
        for (int i = 0; i < Note_Range.Length; i++)
        {
            Note_Range[i].SetActive(true);

            NoteCon = Note_Range[i].GetComponent<NoteMovementFunction>();
            NoteCon.Init_Note_Move(Present_Note_Rotate, Present_Note_Speed);



            yield return new WaitForSeconds(delay);
        }

        for(int i = 0; i<Note_Range.Length; i++) 
        {
            NoteCon = Note_Range[i].GetComponent<NoteMovementFunction>();
            
            NoteCon.Note_IsStay();
            yield return new WaitForSeconds(delay);
        }
    }


}






