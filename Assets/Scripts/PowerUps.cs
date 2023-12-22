using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUps : MonoBehaviour{
    public static PowerUps Instance{ get; private set; }
    
    [SerializeField] private List<GameObject> powerUps;
    private Vector3 powerUpPosition;
    private int _width = 20;
    private int _height = 20;
    private float destroyInterval = 3f;
    private GameObject previousPowerUp;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(Instance);
        }
    }

    private void Start(){
        previousPowerUp = SpawnPowerUp();
    }

    private void Update(){
        destroyInterval -= Time.deltaTime;
        if (destroyInterval <= 0){
            Destroy(previousPowerUp);
            previousPowerUp = SpawnPowerUp();
            destroyInterval = 3f;
        }
    }

    public GameObject SpawnPowerUp(){
        int i = powerUps.Count;
        int randomPowerUp = Random.Range(0, i);
        powerUpPosition = new Vector3(Random.Range(0, _width), Random.Range(0, _height), 0);
        return Instantiate(powerUps[randomPowerUp], powerUpPosition, Quaternion.identity);
    }
}
