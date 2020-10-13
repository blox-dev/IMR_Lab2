
using System;
using UnityEngine;
using VRTK;

public class lineDrawingScript : MonoBehaviour
{
    public VRTK_DestinationMarker pointer;

    protected virtual void OnEnable()
    {
        pointer = (pointer == null ? GetComponent<VRTK_DestinationMarker>() : pointer);

        if (pointer != null)
        {
            pointer.DestinationMarkerHover += DestinationMarkerHover;
        }
        else
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTKExample_PointerObjectHighlighterActivator", "VRTK_DestinationMarker", "the Controller Alias"));
        }
    }

    protected virtual void OnDisable()
    {
        if (pointer != null)
        {
            pointer.DestinationMarkerHover -= DestinationMarkerHover;
        }
    }

    private Vector3 last_pos;
    private int lindex = 0;
    private void DestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
    {

        GameObject chalk = GameObject.Find("chalk");
        chalk.GetComponent<VRTK_InteractableObject>().IsGrabbed();
        if (chalk.GetComponent<VRTK_InteractableObject>().IsGrabbed())
        {
            if (e.target.name == "blackboard")
            {
                if (last_pos == Vector3.zero)
                    last_pos = e.destinationPosition;
                else
                {
                    GameObject lineObject = new GameObject("Line" + lindex++);
                    lineObject.AddComponent<LineRenderer>();

                    LineRenderer line = lineObject.GetComponent<LineRenderer>();

                    line.positionCount = 2;
                    line.SetPosition(0, last_pos);
                    line.SetPosition(1, e.destinationPosition);
                    line.startWidth = 0.1f;
                    line.endWidth = 0.1f;
                    line.useWorldSpace = true;
                    last_pos = e.destinationPosition;
                }
            }
        }
        
    }
    void OnApplicationQuit()
    {
        for (int i = 0; i < lindex; i++)
        {
            GameObject line = GameObject.Find("Line" + i);
            Destroy(line);
        }
    }
}