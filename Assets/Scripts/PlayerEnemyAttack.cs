using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyAttack : MonoBehaviour
{
    
    [SerializeField] private GameObject _bullet1;
    [SerializeField] private Transform _bullet_hole_3;

   

  

    void Start()
    {

    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Gun"))
        {
            GameObject bullet_ins1 = Instantiate(_bullet1, _bullet_hole_3.position, Quaternion.identity);
            PlayerAttack b = bullet_ins1.GetComponent<PlayerAttack>();
            b.SetPlayer(other.gameObject);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        transform.LookAt(other.gameObject.transform);
    }
}
