using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    NonMonoClass mNonMono;
  
    private void Awake()
    {
        //Debug.Log("Awake is called!");
        
    }

    private void OnEnable()
    {
        //Debug.Log("OnEnable is called!");

    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start is called!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update is called!");
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("W and mouse r down");
            // move forward
            Debug.Log(transform.position , this.gameObject);
            //Camera.main.gameObject.transform.position = 
            
        }
    }
}
