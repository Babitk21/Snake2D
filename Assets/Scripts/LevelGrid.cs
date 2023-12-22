using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class LevelGrid {

    private Vector2Int foodGridPosition;
    private Vector2Int venomGridPosition;
    private GameObject foodGameObject;
    private GameObject venomGameObject;
    private int width;
    private int height;
    private Snake snake;
    private Snake2 snake2;


    public LevelGrid(int width, int height) {
        this.width = width;
        this.height = height;
    }

    public void Setup(Snake snake) {
        this.snake = snake;

        SpawnFood();
        SpawnVenom();
    }    public void Setup2(Snake2 snake2) {
        this.snake2 = snake2;

    }

    private void SpawnFood() {
        do {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition) != -1);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;
        foodGameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    private void SpawnVenom(){
        do{
            venomGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetFullSnakeGridPositionList().IndexOf(venomGridPosition) != -1);

        venomGameObject = new GameObject("Venom", typeof(SpriteRenderer));
        venomGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.venomSprite;
        venomGameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        venomGameObject.transform.position = new Vector3(venomGridPosition.x, venomGridPosition.y);
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition) {
        if (snakeGridPosition == foodGridPosition) {
            Object.Destroy(foodGameObject);
            SpawnFood();
            return true;
        }
        else {
            return false;
        }
    }

    public bool TrySnakeEatVenom(Vector2Int snakeGridPosition){
        if (snakeGridPosition == venomGridPosition){
            Object.Destroy(venomGameObject);
            SpawnVenom();
            return true;
        }
        else{
            return false;
        }
    }
    
    public Vector2Int ValidateGridPosition(Vector2Int gridPosition) {
        if (gridPosition.x < 0) {
            gridPosition.x = width - 1;
        }
        if (gridPosition.x > width - 1) {
            gridPosition.x = 0;
        }
        if (gridPosition.y < 0) {
            gridPosition.y = height - 1;
        }
        if (gridPosition.y > height - 1) {
            gridPosition.y = 0;
        }
        return gridPosition;
    }
}
