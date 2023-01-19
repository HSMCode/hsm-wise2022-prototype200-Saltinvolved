using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
 public float power = 10f;
 public Rigidbody rb;
 public GameObject AstroBoi;
 public Vector3 minPower;
 public Vector3 maxPower;

 Camera cam;
 Vector3 force;
 Vector3 startPoint;
 Vector3 endPoint;

 private void Start()
 {
    cam = Camera.main;
 }
  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
        Debug.Log("Right Mouse Button");
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        startPoint.z = 15;
        Debug.Log("startPoint");
    }

    if (Input.GetMouseButtonUp(0))
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        endPoint.z =15;

        force = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
        rb.AddForce(force * power, ForceMode.Impulse);
    }
  }
}

