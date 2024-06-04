using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera target")]
    public Transform target; //target camera follows
    public float smoothing;

    [Header("Camera Bounds")]
    public Vector2 maxPosition;
    public Vector2 minPosition;

    [Header("Camera Position Reset")]
    public VectorValue camMin;
    public VectorValue camMax;

    // Start is called before the first frame update
    void Start()
    {
        maxPosition = camMax.initialValue;
        minPosition = camMin.initialValue;

        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // LastUpdate is called last in frame
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position=Vector3.Lerp(transform.position, targetPosition, smoothing); //lerp moves camera to target
            
        }
    }
}
