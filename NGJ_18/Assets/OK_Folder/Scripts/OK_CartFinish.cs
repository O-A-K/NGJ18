using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK_CartFinish : MonoBehaviour
{
    public GameObject GO_finishDoors;
    private bool BL_finishDoorsActive;

	// Use this for initialization
	void Start () {

        GO_finishDoors.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider cl_other)
    {
        if (cl_other.gameObject.tag == "CartStop")
        {
            BL_finishDoorsActive = true;
            GO_finishDoors.SetActive(true);
        }
    }
}
