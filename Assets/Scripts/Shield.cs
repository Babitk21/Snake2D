using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.CompareTag("Snake")){
            Snake.Instance.SetIsShieldActive(true);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Snake2")){
            Snake2.Instance.SetIsShieldActive(true);
            Destroy(gameObject);
        }
    }
}
