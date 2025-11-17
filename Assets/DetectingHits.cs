using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingHits : MonoBehaviour
{
    public int scorePerFruit = 1;
    public GameObject popEffect; // optional

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            // spawn VFX
            if (popEffect != null)
            {
                Instantiate(popEffect, other.transform.position, Quaternion.identity);
            }

            // update score
            GameManager.Instance.AddScore(scorePerFruit);

            // destroy fruit
            Destroy(other.gameObject);
        }
    }
}
