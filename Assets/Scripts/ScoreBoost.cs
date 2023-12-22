using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoost : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Snake") || other.CompareTag("Snake2")){
            ScoreKeeper.Instance.SetScore(10);
            Destroy(gameObject);
        }
    }
}
