using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;


public class ARTouchDestroy : MonoBehaviour
{
    public Transform arCamera;

    void Update()
    {
        // Detect touch input on the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Destroy(gameObject);
        }
    }
}
//using UnityEngine;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;

//public class ARTouchDestroy : MonoBehaviour
//{
//    public ARRaycastManager arRaycastManager; // Reference to the ARRaycastManager
//    public GameObject objectToDestroy; // The object that will be destroyed

//    private void Update()
//    {
//        // Detect touch input on the screen
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);
//            Ray ray = Camera.main.ScreenPointToRay(touch.position);

//            // Raycast to detect where the touch intersects with AR objects
//            if (touch.phase == TouchPhase.Began)
//            {
//                RaycastHit hit;
//                if (Physics.Raycast(ray, out hit))
//                {
//                    // Check if the raycast hits the object to destroy
//                    if (hit.transform.gameObject == objectToDestroy)
//                    {
//                        // Destroy the object
//                        Destroy(hit.transform.gameObject);
//                    }
//                }
//            }
//        }
//    }
//}

//using UnityEngine;
//using Niantic.ARDK.AR;
//using Niantic.ARDK.AR.Awareness;
//using Niantic.ARDK.AR.Session;
//using Niantic.ARDK.Utilities.Input;
//using UnityEngine.InputSystem;

//public class LightshipTouchDestroy : MonoBehaviour
//{
//    private IARSession _arSession;  // AR session
//    public GameObject objectToDestroy; // The object that will be destroyed

//    void Start()
//    {
//        // Initialize AR session
//        _arSession = ARSessionFactory.Session;
//    }

//    void Update()
//    {
//        // Check for touch input
//        if (Touchscreen.current.primaryTouch.press.isPressed)
//        {
//            // Get the touch position in screen space
//            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

//            // Perform a hit test to check if the touch hits an AR object
//            var hits = _arSession.Raycast(touchPosition);

//            foreach (var hit in hits)
//            {
//                // Check if the raycast hit the object to destroy
//                if (hit.GameObject == objectToDestroy)
//                {
//                    // Destroy the object
//                    Destroy(hit.GameObject);
//                }
//            }
//        }
//    }
//}
