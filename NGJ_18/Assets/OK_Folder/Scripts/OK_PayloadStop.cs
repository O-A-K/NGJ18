using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_PayloadStop : MonoBehaviour {

    public GameObject GO_Cart;
    
    // Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		

	}

    private void OnTriggerEnter(Collider cl_other)
    {
        GO_Cart.GetComponent<Battlehub.SplineEditor.SplineFollow>().IsRunning = false;
        print("I am a Stop");
    }

    private void OnTriggerExit(Collider cl_other)
    {
        GO_Cart.GetComponent<Battlehub.SplineEditor.SplineFollow>().IsRunning = true;
        print("I am a Go");
    }
}
