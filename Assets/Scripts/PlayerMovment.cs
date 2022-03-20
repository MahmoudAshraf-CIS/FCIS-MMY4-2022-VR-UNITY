using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rb == null)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            //rb.AddForce(new Vector3(0, 0, speed));
            //rb.AddForce(transform.forward * speed);
            //Debug.Log(rb.velocity );
            rb.velocity = Vector3.zero;
            rb.AddRelativeForce(new Vector3(0, 0, speed));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter" + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit" + collision.gameObject.name);

    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay" + collision.gameObject.name);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter" + other.gameObject.name);

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit" + other.gameObject.name);

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay" + other.gameObject.name);
    }
}
