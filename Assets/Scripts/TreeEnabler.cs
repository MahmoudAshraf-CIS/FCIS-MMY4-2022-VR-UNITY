using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnabler : MonoBehaviour
{
    public GameObject[] mTrees;
    // Start is called before the first frame update
    void Start()
    {
        EnableAllObjects();
    }


    void EnableAllObjects()
    {
        foreach (var tree in mTrees)
        {
            tree.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        mTrees[Random.Range(0, mTrees.Length - 1)].SetActive(true);

        // if all of them are enabled then disaple thtem again
        bool allDisabled = true;

        foreach (var tree in mTrees)
        {
            allDisabled = allDisabled && tree.gameObject.activeInHierarchy;
        }
        if (allDisabled)
        {
            EnableAllObjects();
        }
    }
}
