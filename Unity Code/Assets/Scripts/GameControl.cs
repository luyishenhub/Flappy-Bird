//GameControl idea: Singleton
// It is the ONE AND ONLY game controller we can have 

//public variables shown on the inspector

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //allows us to manage the scenes (ex. reload the scene)
using UnityEngine.UI; // input the UI for displaying the Text;

public class GameControl : MonoBehaviour {

    public static GameControl instance; //making it static cause it to associate with other scripts easier, it belongs to the class but not the object, so the symbol (pointer?) is unique, but not eh value that it holds is unique
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f; // the scrolling speed variable can be accessed by other scripts
    public Text scoreText;
    private int score = 0;


	// Use this for initialization
    void Awake () { //before start()-> used for originally set up

        if(instance == null){ //if there are no other gameControls
            instance = this; //this gameControl is the ONE AND ONLY gameControl
        }
        if(instance != this){ //if the gameControl is not this gameControl
            Destroy(gameObject); // then destroy this game object ( should be small case because GameObject is a variable type, but gameObject is the game object in the inspector (a physical shape, item)
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(gameOver==true && Input.GetMouseButtonDown(0)) //if the bird is dead and left clicked the screen again
        {
            //reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            //"LoadScene": reload the scene
            //"GetActiveScene": the scene that is currently active
            //"buildIndex": returns the index of the scene that is in the build settings
        }
		
	}

    public void BirdScored(){
        if (gameOver==true){ //if the bird is dead, don't score any points, just return the value without doing anything
            return;
        }
        score++; // if this function is called, then plus one for the score
        scoreText.text = "Score: " + score.ToString(); //".text": the string value the Text displays
    }

    //BirdDie function should not be in the bird script, because it does not belong to the bird icon. The overall controller controls when would the text appear
    public void BirdDie (){ // static GameControl variable "instance" makes easier to be called in other scripts
        gameOverText.SetActive(true); //when bird dies, then the gameOverText shows up (active=true)
        gameOver = true;
    }
}
