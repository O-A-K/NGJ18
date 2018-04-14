using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JC_SwitchManager : MonoBehaviour
{
    [SerializeField] private List<JC_Switch> allSwiches = new List<JC_Switch>();
    public int breakingPoint;
    public int onCounter;

    // Use this for initialization
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (onCounter >= breakingPoint)
        {
            print("Breaking point");

            foreach (JC_Switch Switch in allSwiches)
            {

                Switch.isOn = false;
                Switch.HasBroken();

            }
            onCounter = 0;
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
