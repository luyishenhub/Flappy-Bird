using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d; // its a rigit body because it needs to do physics

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0); // the horizontal speed would be the same as scrollSpeed from the GameControl script
	}
	
	// Update is called once per frame
	void Update () {
        if(GameControl.instance.gameOver == true){ // when the game is over
            rb2d.velocity = Vector2.zero; //set the velocity to zero
        }
		
	}
}
//since we need this script for both the ground and columns, so in the inspector, i select this script for both the ground and the columns (without having to program for two different scripts
