using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized]public Vector3 position;
    [SerializeField] private float _speed = 10;

    private void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);
        if(transform.position == position)
            Destroy(gameObject);
    }
}
