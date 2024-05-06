using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class OutputNodeScript : MonoBehaviour
{
    public GameObject OutputNode;
    public bool foundNode=false;
    public Vector3 outPos;
    public LineRenderer lineRenderer;
    public LineRenderer lineRendererPrefab;
    public GameObject circle;
    public GameObject square;
    SwitchScript switchscript;
    InputNodeScript inputi;
    NotGate notgatescript;
    AndGate AndGateScript;
    OrGate OrGateScript;

    public bool switchON;

    private void Update()
    {
        string parentia = transform.parent.name;
        string[] parts = parentia.Split(' ');
        string parenti = parts[0];

        if (parenti == "switch")
        {
            circle = transform.parent.GetChild(0).gameObject;
            switchscript = circle.GetComponent<SwitchScript>();
            switchON = switchscript.On;
            if (foundNode)
            {
                inputi.inputOn = switchON;
            }
        }

        if(parenti == "NOT")
        {
            square= transform.parent.GetChild(0).gameObject;
            notgatescript = square.GetComponent<NotGate>();
            switchON = notgatescript.output;
            if (foundNode)
            {
                inputi.inputOn = switchON;
            }
        }
        if (parenti == "AND")
        {
            square = transform.parent.GetChild(0).gameObject;
            AndGateScript = square.GetComponent<AndGate>();
            switchON = AndGateScript.output;
            if (foundNode)
            {
                inputi.inputOn = switchON;
            }
        }

        if (parenti == "OR")
        {
            square = transform.parent.GetChild(0).gameObject;
            OrGateScript = square.GetComponent<OrGate>();
            switchON = OrGateScript.output;
            if (foundNode)
            {
                inputi.inputOn = switchON;
            }
        }



    }

    private void OnMouseDrag()
    {
        lineRenderer.enabled = true;
        foundNode = false;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        newPos.z = 0;
        outPos = OutputNode.transform.position;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPos, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            UpdateLineRenderer(outPos, collider.transform.position);
            inputi = collider.GetComponent<InputNodeScript>();
            inputi.inputOn = switchON;
            Debug.Log(collider.name);
            foundNode = true;
            return;
        }
        UpdateLineRenderer(outPos, newPos);
    }

    private void OnMouseUp()
    {
        if (foundNode == false)
        {
            lineRenderer.enabled = false;
        }

    }

    private void UpdateLineRenderer(Vector3 startPos, Vector3 endPos)
    {
        
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
        //circle = transform.parent.GetChild(0).gameObject;
        //switchscript = circle.GetComponent<SwitchScript>();
        ////Debug.Log(switchscript.On);
        //Debug.Log(transform.parent.position);
        //objectTofind = transform.parent.GetChild(0).gameObject;
        //Debug.Log(objectTofind.name);
    }
}
