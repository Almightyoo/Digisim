using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class NotGate : MonoBehaviour
{
    public bool pinA;
    public bool output;
    public GameObject OutputPin;
    OutputNodeScript outputnodescript;
    private void Update()
    {
        if (pinA)
        {
            output = false;
        }
        else
        {
            output = true;
        }

        string parentia = transform.parent.name;
        string[] parts = parentia.Split(' ');
        string parenti = parts[0];

        if (parenti == "NOT")
        {
            OutputPin = transform.parent.GetChild(2).gameObject;
            outputnodescript = OutputPin.GetComponent<OutputNodeScript>();
            outputnodescript.switchON = output;
        }

    }
}
