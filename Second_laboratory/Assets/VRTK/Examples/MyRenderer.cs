using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MyRenderer : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;
    public GameObject chalkPoint;
    public LineRenderer lineRenderer;

    public VRTK_ControllerEvents controller;
    public VRTK_InteractableObject interactableObject;
    bool isDrawing = false;
    bool isGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        controller.TriggerPressed += _TriggeredPressed;
        interactableObject.InteractableObjectGrabbed += _ObjectGrabbed;
        CreateLine();
        controller.TriggerReleased += _TriggerReleased;
        interactableObject.InteractableObjectUngrabbed += _ObjectReleased;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrawing && isGrabbed)
        {
            UpdateLine(chalkPoint.transform.position);
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
    }

    void UpdateLine(Vector3 newChalkPos)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newChalkPos);
    }

    void _TriggeredPressed(object sender, ControllerInteractionEventArgs eventArgs)
    {
        isDrawing = true;
        CreateLine();
    }

    void _TriggerReleased(object sender, ControllerInteractionEventArgs eventArgs)
    {
        isDrawing = false;
    }

    void _ObjectGrabbed(object sender, InteractableObjectEventArgs eventArgs)
    {
        isGrabbed = true;
        CreateLine();
    }

    void _ObjectReleased(object sender, InteractableObjectEventArgs eventArgs)
    {
        isGrabbed = false;
    }

}
