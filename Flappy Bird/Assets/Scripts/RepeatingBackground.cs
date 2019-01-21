using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>(); // set the current BoxCollider2D as this one
        groundHorizontalLength = groundCollider.size.x; // get the value of the x length
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x< -groundHorizontalLength){
            RepositionBacground();
        }

    }
    private void RepositionBacground(){
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0); // set the transformation (offset) as move the double value of the horizontalLenth
        transform.position = (Vector2)transform.position + groundOffset; // "this" gameObject's postion equals to its original value plus the offset value
        //transform contains: positon, rotation, scale
    }
}
