using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovementFunction : MonoBehaviour
{
    // Start is called before the first frame update

    bool IsStay;

    Vector3 rotation;
    float speed;

    private void Awake()
    {
        IsStay = false;
    }





    public void Note_IsStay()
    {
        IsStay = !IsStay;
    }

    public void Init_Note_Move(Vector3 Rotation, float Speed)
    {
        rotation = Rotation;
        speed = Speed;
        Debug.Log(speed);
    }



    void Update()
    {
        if (!IsStay)
        {
            gameObject.transform.rotation = Quaternion.FromToRotation(new Vector3(0,0,0),rotation);

            gameObject.transform.position += speed * Vector3.right * Time.deltaTime;

            GetComponent<SpriteRenderer>().enabled = true;

            if(name.ToCharArray()[0] != '0')
            {
                GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 15f);
            }


        }
        else if(name.ToCharArray()[0] != '0')
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }


}
