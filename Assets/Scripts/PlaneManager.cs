using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneManager : MonoBehaviour
{

    public static List<ARPlane> planes = new List<ARPlane>();
    public void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARPlane> changes)
    {
        planes = new List<ARPlane>();
        foreach (var plane in changes.added)
        {
            planes.Add(plane);
        }

        foreach (var plane in changes.updated)
        {
            planes.Add(plane);
        }


    }
}

