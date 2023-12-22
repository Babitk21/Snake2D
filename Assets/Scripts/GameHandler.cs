using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    [SerializeField] private Snake snake;
    [SerializeField] private Snake2 snake2;

    private LevelGrid levelGrid;
    private PowerUps powerUps;

    private void Start() {

        levelGrid = new LevelGrid(20, 20);

        snake.Setup(levelGrid);
        snake2.Setup(levelGrid);
        levelGrid.Setup(snake);
        levelGrid.Setup2(snake2);
    }

}
