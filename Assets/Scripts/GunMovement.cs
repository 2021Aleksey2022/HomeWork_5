using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GunMovement : MonoBehaviour
{
    public Transform EditPoint;
    public Transform EditPoint1;
    public float arriveTime = 3f;

    void Update()
    {
        transform.position = Vector3.Lerp(EditPoint1.position, EditPoint.position, Mathf.PingPong(Time.time / arriveTime, 1f));
               
    }
}
