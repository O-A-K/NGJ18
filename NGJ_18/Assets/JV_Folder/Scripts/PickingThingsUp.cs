using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingThingsUp : MonoBehaviour
{
    public GameObject PC;
    public GameObject LookingAt;
    public GameObject WasLookingAt;
    [HideInInspector]
    public bool IsLookingAtSomething = false;
    [HideInInspector]
    public static Material[] No_Outline;
    private bool CarryingObject = false;
    private GameObject CarriedObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region
        //int layermask = 1 << 8;
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layermask ))
        //{
        //    if (hit.transform.gameObject.layer == 8 && hit.distance <= 5.0f)
        //    {
        //        IsLookingAtSomething = true;
        //        No_Outline = hit.transform.gameObject.GetComponent<Renderer>().materials;
        //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green );
        //        RaycastTarget = hit.transform.gameObject;
        //        if (Input.GetKeyDown(KeyCode.L) && !CarryingObject)
        //        {
        //            Debug.Log("Picked up");
        //            CarryingObject = true;
        //            hit.transform.parent = this.transform;
        //            CarriedObject = hit.transform.gameObject;
        //        }
        //        else if (Input.GetKeyDown(KeyCode.L) && CarryingObject)
        //        {
        //            Debug.Log("Dropped Object");
        //            CarryingObject = false;
        //            CarriedObject.transform.parent = null;
        //        }
        //    }
        //    else
        //    {
        //        IsLookingAtSomething = false;
        //        hit.transform.gameObject.GetComponent<Renderer>().materials = No_Outline;
        //    }
        //}
        #endregion

        if (IsLookingAtSomething)
        {
            LookingAt = this.transform.gameObject;
            //Debug.Log("I am looking at " + LookingAt);
            if (Input.GetKeyDown(KeyCode.L) && !CarryingObject)
            {
                Debug.Log("Picked up");
                CarryingObject = true;
                this.transform.parent = PC.transform;
                CarriedObject = this.transform.gameObject;
            }
            else if (Input.GetKeyDown(KeyCode.L) && CarryingObject)
            {
                Debug.Log("Dropped Object");
                CarryingObject = false;
                CarriedObject.transform.parent = null;
            }
        }
        else if (!IsLookingAtSomething)
        {
            GameObject temp = LookingAt;
            WasLookingAt = temp;
            //LookingAt = null;

            //Debug.Log("I was looking at " + WasLookingAt);
        }
    }

    void OnTriggerStay(Collider Player)
    {
        LookingAt = this.transform.gameObject;
        PC = Player.transform.gameObject;

        IsLookingAtSomething = true;
    }

    //void OnTriggerEnter(Collider Player)
    //{
    //    IsLookingAtSomething = true;
    //}

    void OnTriggerExit(Collider Player)
    {
        IsLookingAtSomething = false;
    }

}
