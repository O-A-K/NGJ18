using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_CartPressure : MonoBehaviour {

    public GameObject GO_Cart;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider cl_other)
    {
        if (cl_other.gameObject.layer == 9)
        GO_Cart.GetComponent<Battlehub.SplineEditor.SplineFollow>().IsRunning = true;
    }

    private void OnTriggerExit(Collider cl_other)
    {
        if (cl_other.gameObject.layer == 9)
            GO_Cart.GetComponent<Battlehub.SplineEditor.SplineFollow>().IsRunning = false;
    }
}
