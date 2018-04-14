using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JC_SwitchManager : MonoBehaviour
{
    [SerializeField] private List<JC_Switch> allSwiches = new List<JC_Switch>();
    public int breakingPoint;
    int onCounter;

    // Use this for initialization
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (onCounter >= breakingPoint)
        {
            //SHIT HAPPENS
        }
    }

    public void AddOnSwitch()
    {
        onCounter++;
    }

    public void RemoveOnSwitch()
    {
        onCounter--;
    }
}
