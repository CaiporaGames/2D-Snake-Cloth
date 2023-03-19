using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle1 : MonoBehaviour
{

    [SerializeField] int length; //tail length = how many segments it have
    [SerializeField] Transform targetDirection;
    [SerializeField] float minimumDistanceFromTarget = 1f;
    [SerializeField] float SmoothSpeed = 1f;
    [SerializeField] float wiggleSpeed = 1f;
    [SerializeField] float wiggleMagnitude = 1f;
    [SerializeField] Transform wiggleDirection;
    LineRenderer lineRenderer;
    Vector3[] segmentsPosition;
    Vector3[] segmentsVelocity;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = length;
        segmentsPosition = new Vector3[length];
        segmentsVelocity = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {
        wiggleDirection.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time*wiggleSpeed)*wiggleMagnitude);
        segmentsPosition[0] = targetDirection.position;

        for(int i = 1; i < segmentsPosition.Length; i++)
        {
            segmentsPosition[i] = Vector3.SmoothDamp(segmentsPosition[i],
             segmentsPosition[i-1] + targetDirection.right * minimumDistanceFromTarget, 
             ref segmentsVelocity[i], SmoothSpeed);
        }

        lineRenderer.SetPositions(segmentsPosition);
    }
}
