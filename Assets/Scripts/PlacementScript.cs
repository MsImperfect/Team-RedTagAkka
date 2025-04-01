using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlacementScript : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private List<GameObject> spawnPrefab;
    private ARRaycastManager raycastManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchposition;
            Touch touch = Input.GetTouch(0);
            touchposition = touch.position;
            ARRaycasting(touchposition);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
            ARRaycasting(mousePosition2D);
        }



        void ARRaycasting(Vector2 pos)
        {
            List<ARRaycastHit> hits = new();

            if (raycastManager.Raycast(pos, hits, trackableTypes: UnityEngine.XR.ARSubsystems.TrackableType.PlaneEstimated))
            {
                Pose pose = hits[0].pose;
                ARInstatiation(pose.position, pose.rotation);
            }

        }

        void ARInstatiation(Vector3 pos, Quaternion rot)
        {
            spawnPrefab.Add(Instantiate(prefab, pos, rot));
        }
    }
}
