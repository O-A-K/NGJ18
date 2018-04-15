using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public bool rot_x;
    public bool rot_y;
    public bool rot_z;
    public float speed = 10f;
	
	// Update is called once per frame
	void Update () {
		if (rot_x == true)
        {
            transform.Rotate(speed, 0, 0);
        }
        else if(rot_y == true)
        {
            transform.Rotate(0, speed, 0);
        }
        else if(rot_z == true)
        {
            transform.Rotate(0, 0, speed);
        }
	}
}
