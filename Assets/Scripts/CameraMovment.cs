using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField]
    private float mLinearSpeed = 10, mAngolarSpeed = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.localPosition += new Vector3(0, 0, .1f);
            //transform.Translate(0, 0, mSpeed);
            transform.position += transform.forward * mLinearSpeed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * -mLinearSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * mLinearSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -mLinearSpeed * Time.deltaTime;
        }


        //Rotation
         
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, mAngolarSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0,-mAngolarSpeed * Time.deltaTime, 0);
        }

    }
}
