using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    [NonSerialized] public Vector3 posotion;
    public float _speed = 10;
    private GameObject _player;

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }
    private void Update()
    {
        if (_player != null)
        {
            gameObject.transform.position =
               Vector3.MoveTowards(transform.position, _player.transform.position, 4 * Time.deltaTime);
            
        }     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("PlayerBullet"))
        {
           gameObject.SetActive(false);
            other.gameObject.SetActive(true);
        }
    }
}
