using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class InputNodeScript : MonoBehaviour
{
    public bool inputOn;
    public GameObject square;
    public GameObject circle;
    NotGate NotGateScript;
    AndGate AndGateScript;
    OrGate OrGateScript;
    OutputScript outputscript;

    private void Update()
    {
        string parentia = transform.parent.name;
        string[] parts = parentia.Split(' ');
        string parenti = parts[0];
        string nawa = transform.name;
        if (parenti == "NOT")
        {
            square = transform.parent.GetChild(0).gameObject;
            NotGateScript = square.GetComponent<NotGate>();
            NotGateScript.pinA = inputOn;
        }

        if(parenti == "Output")
        {
            circle = transform.parent.GetChild(0).gameObject;
            outputscript = circle.GetComponent<OutputScript>();
            outputscript.outputOn = inputOn;
        }

        if(parenti == "AND" && nawa=="PinA")
        {
            square = transform.parent.GetChild(0).gameObject;
            AndGateScript = square.GetComponent<AndGate>();
            AndGateScript.pinA = inputOn;

        }

        if (parenti == "AND" && nawa == "PinB")
        {
            square = transform.parent.GetChild(0).gameObject;
            AndGateScript = square.GetComponent<AndGate>();
            AndGateScript.pinB = inputOn;

        }

        if (parenti == "OR" && nawa == "PinA")
        {
            square = transform.parent.GetChild(0).gameObject;
            OrGateScript = square.GetComponent<OrGate>();
            OrGateScript.pinA = inputOn;

        }

        if (parenti == "OR" && nawa == "PinB")
        {
            square = transform.parent.GetChild(0).gameObject;
            OrGateScript = square.GetComponent<OrGate>();
            OrGateScript.pinB = inputOn;

        }


    }
}
