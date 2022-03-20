using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float health = 100;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.gameObject.name);
        if(collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            health -= 50;
            if(health <= 0)
            {
                Destroy(this.gameObject);
                // animation of theath - destroy after the animation is completed
                // Add to the score
                //ScoreManager sm = FindObjectOfType<ScoreManager>();
                //if (sm)
                //{
                //    sm.AddScore(10);
                //}

                ScoreManager.Instance.AddScore(10);
            }
        }
    }


    public void ApplyHit()
    {
        health -= 50;
        if(health <= 0)
        {
            Destroy(this.gameObject);
            ScoreManager.Instance.AddScore(10);
        }
    }
}
