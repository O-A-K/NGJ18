using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL_CameraFollow : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    public GameObject player2;

    public Vector3 midpoint;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position + new Vector3(1, 1, 1);
    }

    void Update()
    {
        midpoint = Vector3.Lerp(player.transform.position, player2.transform.position, 0.5f);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.LookAt(midpoint);

        
    }
}
