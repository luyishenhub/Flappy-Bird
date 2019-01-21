//this is one of the scripts for the game controller

//Prefab: gameobjects with its properties, act like a template

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {
    public int columnPoolSize = 5;
    public GameObject columnPrefabs;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f; // what do those units mean

    private GameObject[] columns; // a group of 5 of the game objects of the prefab "column:
    private Vector2 objectPoolPostion = new Vector2(-15f, 25f);
    private float timeSinceLastSpawned;
    private int currentColumn = 0;
    private float spawnXPosition = 10f;


    // Use this for initialization
    void Start () {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++) //type "for" and then double "tab" to get the short cut for "for loop"
        {
            columns[i] = (GameObject)Instantiate(columnPrefabs, objectPoolPostion, Quaternion.identity);
            //instantiate: clones of gameobjects
            //Instantiate (origianl gameObject, position, rotation in Quaternion)
            //Quaternion.identity: no rotation
        }

    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime; //"Time.deltaTime": seconds it takes to finish one frame

        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate){ //adds the position of the column for every spawnRate of time (single, not in a group of 5)

            timeSinceLastSpawned = 0;//recount from beginning
            float spawnYPosition = Random.Range(columnMin, columnMax); // generate random number from the min to the max, for the y position of the column
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);// set the column posiiton with x and y values
            currentColumn++;
            if(currentColumn >= columnPoolSize){
                currentColumn = 0; // if the column index is more than 5, reset to the 0th of the group of 5
            }
        }
		
	}
}
