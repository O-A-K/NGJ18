using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingThingsUp : MonoBehaviour
{
    public int playerNumber = 0;
    public GameObject PC;
    public GameObject LookingAt;
    public GameObject WasLookingAt;
    bool pcInside;
    [HideInInspector]
    public bool IsLookingAtSomething;
    [HideInInspector]
    public static Material[] No_Outline;
    private bool CarryingObject = false;
    private GameObject CarriedObject;

    // Use this for initialization
    void Start()
    {
        //if (playerNumber == 0)
        //{
        //    Debug.LogError("Player number asshat");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pcInside);
        InRangeOfSwitch();
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
        if (pcInside)
        {
            IsLookingAtSomething = true;
        }
        else if (!pcInside)
        {
            IsLookingAtSomething = false;
        }
        if (IsLookingAtSomething)
        {
            if (playerNumber == 1)
            {
                LookingAt = this.transform.gameObject;
                PC = GameManager.gm.PlayerOne.transform.gameObject;
                WasLookingAt = null;
            }
            else if (!pcInside && playerNumber == 2)
            {
                LookingAt = this.transform.gameObject;
                PC = GameManager.gm.PlayerTwo.transform.gameObject;
                WasLookingAt = null;
            }
        }
        else if (!IsLookingAtSomething)
        {
            if (playerNumber == 1)
            {
                WasLookingAt = this.transform.gameObject;
                IsLookingAtSomething = false;
                LookingAt = null;
            }
            else if (playerNumber == 2)
            {
                WasLookingAt = this.transform.gameObject;
                IsLookingAtSomething = false;
                LookingAt = null;
            }
        }
        
        #region
        //if (IsLookingAtSomething)
        //{
        //    //LookingAt = this.transform.gameObject;
        //    //Debug.Log("I am looking at " + LookingAt);
        //    if (Input.GetKeyDown(KeyCode.L) && !CarryingObject)
        //    {
        //        Debug.Log("Picked up");
        //        CarryingObject = true;
        //        this.transform.parent = PC.transform;
        //        CarriedObject = this.transform.gameObject;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.L) && CarryingObject)
        //    {
        //        Debug.Log("Dropped Object");
        //        CarryingObject = false;
        //        CarriedObject.transform.parent = null;
        //    }
        //}
        //else if (!IsLookingAtSomething)
        //{
        //    //WasLookingAt = LookingAt;
        //    LookingAt = null;

        //    //Debug.Log("I was looking at " + WasLookingAt);
        //}
#endregion
    }

    bool InRangeOfSwitch()
    {
        if (playerNumber == 1)
        {
            if ((GameManager.gm.PlayerOne.transform.position - transform.position).sqrMagnitude <= 2.25f)
            {
                return pcInside = true;
            }
            else
            {
                return pcInside = false;
            }
        }
        else if (playerNumber == 2)
        {
            if ((GameManager.gm.PlayerTwo.transform.position - transform.position).sqrMagnitude <= 2.25f)
            {
                return pcInside = true;
            }
            else
            {
                return pcInside = false;
            }
        }
        else
        {
            Debug.LogError("S0mething about playernumber");
            return false;
        }
    }

    //void OnTriggerStay(Collider Player)
    //{
    //    LookingAt = this.transform.gameObject;
    //    PC = Player.transform.gameObject;
    //    WasLookingAt = null;
    //    IsLookingAtSomething = true;
    //}

    //void OnTriggerEnter(Collider Player)
    //{
    //    IsLookingAtSomething = true;
    //}

    //void OnTriggerExit(Collider Player)
    //{
    //    WasLookingAt = this.transform.gameObject;
    //    IsLookingAtSomething = false;
    //    LookingAt = null;
    //}

}
