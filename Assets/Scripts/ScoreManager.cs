using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text mScore;

    int score = 0;

    public static ScoreManager Instance;

    private void Start()
    {
        
        ScoreManager sm = FindObjectOfType<ScoreManager>();
        if (sm != this)
        {
            Destroy(sm.gameObject);
        }
        else
        {
            Instance = sm;
        }
        AddScore(0);
    }


    public void AddScore(int s)
    {
        score += s;
        mScore.text = score.ToString();
    }
}
