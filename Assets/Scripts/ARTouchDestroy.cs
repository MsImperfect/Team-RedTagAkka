//using UnityEngine;

//public class ARMouseDestroy : MonoBehaviour
//{
//    public Transform arCamera;

//    void Update()
//    {
//        // Detect mouse click on the object

//        }
//    }
//}
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ARTouchDestroy : MonoBehaviour
{
    public Transform arCamera;

    void Update()
    {
        // Detect touch input on the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the touched object is the current game object
                if (hit.transform == transform)
                {
                    Destroy(gameObject);
                }
            }
            Debug.Log("Destroyed");

        }
        //else if (Input.GetMouseButtonDown(0))  // 0 corresponds to the left mouse button
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // Check if the clicked object is the current game object
        //        if (hit.transform == transform)
        //        {
        //            Destroy(gameObject);
        //        }
        //    }
        //}
    }
}
