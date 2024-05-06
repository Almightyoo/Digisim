using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrGate : MonoBehaviour
{
    public bool pinA;
    public bool pinB;
    public bool output;
    public GameObject OutputPin;
    OutputNodeScript outputnodescript;

    private void Update()
    {
        if (pinA || pinB)
        {
            output = true;
        }
        else
        {
            output = false;
        }

        string parentia = transform.parent.name;
        string[] parts = parentia.Split(' ');
        string parenti = parts[0];

        if (parenti == "OR")
        {
            OutputPin = transform.parent.GetChild(3).gameObject;
            outputnodescript = OutputPin.GetComponent<OutputNodeScript>();
            outputnodescript.switchON = output;
        }
    }
}
