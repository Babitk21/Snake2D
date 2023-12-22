using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour{
    public static ScoreKeeper Instance{ get; private set; }
    
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    public void SetScore(int score){
        this.score += score;
    }
    private float increaseInterval = 1f;

    private float timer = 0f;

    private void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(Instance);
        }
    }

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        if (timer >= increaseInterval){
            score++;
            timer = 0f;
            scoreText.text = score.ToString();
        }
    }
}
