using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upForce = 200f;

    private bool isDead = false; //initially the bird is not dead
    private Rigidbody2D rb2d;
    private Animator anim;


	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();//check if there is a rigidbody2d component attached to it, if so, then rb2d = that rigidbody2d object
        anim = GetComponent<Animator>();//check if there is a animator...
    }
	
	// Update is called once per frame
	void Update () {
        if(isDead == false){ //if is not dead
            if(Input.GetMouseButtonDown(0)){ //if the mouse left button (its what 0 stands for) is clicked
                rb2d.velocity = Vector2.zero;//the velocity becomes zero //? why tho, since the velocity is always zero?
                rb2d.AddForce(new Vector2(0, upForce)); //add a force of 200f in y direction
                anim.SetTrigger("Flap"); //import the "Flap" trigger here (when the bird is alive and the mouse is clicked)
            }
        }
	}
    private void OnCollisionEnter2D()//when the bird and the ground/columns collides with each other (whenvever collision happens, program will go to this function
    {
        rb2d.velocity = Vector2.zero; // when the bird hits the ground, in order to prevent the birds to slide to the left, set its velocity to 0. (? when did it slide tho?)-> because some forces is applied over multiple frames, so we have to do a fixed update (which is to permentaly set it to zero)
        isDead = true;
        anim.SetTrigger("Die"); //import the "Die" trigger here (when the bird is dead)
        GameControl.instance.BirdDie();
    }
}
