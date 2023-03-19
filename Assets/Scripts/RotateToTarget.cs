using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
   [SerializeField] float rotationSpeed = 1f;
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] Camera mainCamera;

  float angle;
  Vector2 direction;
  Vector2 cursorPosition;
  Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
        direction = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    
        cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, cursorPosition, moveSpeed * Time.deltaTime);
    }
}
