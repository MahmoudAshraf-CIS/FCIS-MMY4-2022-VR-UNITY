using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class Grab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Collider[] colliders;

    // Update is called once per frame
    void Update()
    {
        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Grip)){
            if(colliders!= null && colliders.Length >0)
                LetGo();

            colliders = Physics.OverlapSphere(transform.position, 0.1f);
            if (colliders.Length > 0)
            {
                // grabbing all the available object
                /*foreach (var item in colliders)
                {
                    Debug.Log(item.gameObject.name);
                    item.transform.SetParent(this.transform);
                    Rigidbody rb = item.gameObject.GetComponent<Rigidbody>();
                    if (rb)
                    {
                        rb.useGravity = false;
                        rb.isKinematic = true;
                    }

                }*/

                // grabbing only one of them
                colliders[0].transform.SetParent(this.transform);
                Rigidbody rb = colliders[0].gameObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.useGravity = false;
                    rb.isKinematic = true;
                }


                // search for the nearest one 
                /*Collider c = FindTheNearest(colliders);
                c.transform.SetParent(this.transform);
                Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.useGravity = false;
                    rb.isKinematic = true;
                }*/
            }
        }
      
         
    }

    void LetGo()
    {
        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Grip) && colliders != null && colliders.Length > 0)
        {
            /*foreach (var item in colliders)
            {
                Debug.Log(item.gameObject.name);
                item.transform.SetParent(null);
                Rigidbody rb = item.gameObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.useGravity = true;
                    rb.isKinematic = false;

                    // apply force that is relative to the controller velocity
                }

            }*/

            colliders[0].transform.SetParent(this.transform);
            Rigidbody rb = colliders[0].gameObject.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.useGravity = true;
                rb.isKinematic = false;

                // apply force that is relative to the controller velocity
            }
        }
    }


    Collider FindTheNearest(Collider[] cols)
    {
        int indexOfClose = 0;
        float distance = 99999999;
        for(int i = 0; i < cols.Length; i++)
        {
            if(Vector3.Distance(this.transform.position, cols[i].transform.position) < distance)
            {
                indexOfClose = i;
            }
        }


        return cols[indexOfClose];
    
    }
}
