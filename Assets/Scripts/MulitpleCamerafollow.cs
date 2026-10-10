using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MulitpleCamerafollow : MonoBehaviour
{
    public List<Transform> targets; //= Transform.FindWithTag(targetTag);
    public string targetTag;

    public Vector3 offset;
    public float smoothTime = .5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;

    // void Awake()
    //{
    //  foreach (GameObject go in GameObject.FindGameObjectsWithTag(targetTag))
    //{
    //  targets.Add(go.GetComponent<Transform>());
    //}
    //}

    private void Start()
    {

        cam = GetComponent<Camera>();

    }

    //void Update()
    //{
    //  foreach (GameObject go in GameObject.FindGameObjectsWithTag(targetTag))
    //{
    //  targets.Add(go.GetComponent<Transform>());
    //}
    //}

    private void LateUpdate()
    {

        if (targets.Count == 0)
            return;


        move();
        zoom();

    }

    void zoom()
    {

        float newZoom = Mathf.Lerp(maxZoom, minZoom, getGreatestDistance() / zoomLimiter);
        //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }


    void move()
    {

        Vector3 centerPoint = getCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

    }

    float getGreatestDistance()
    {

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {

            bounds.Encapsulate(targets[i].position);


        }

        return bounds.size.x;

    }


    Vector3 getCenterPoint()
    {

        if (targets.Count == 1)
        {

            return targets[0].position;


        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {


            bounds.Encapsulate(targets[i].position);

        }

        return bounds.center;


    }

    public void getPlayer(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag(targetTag))
            {
                targets.Add(go.GetComponent<Transform>());
            }
        }
    }
}
