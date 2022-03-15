using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject mTreePrefab;
    public float interval = 1;

    // Update is called once per frame
    void Update()
    {
        //interval += Time.deltaTime;
        //if(interval >= 1)
        //{
        //    // spawn
        //    Instantiate(mTreePrefab);

        //}


        

    }

    private void Start()
    {
        //StartCoroutine(Spawn());

        InvokeRepeating("Spawn", 0, interval);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            Instantiate(mTreePrefab);
        }
    }
}
