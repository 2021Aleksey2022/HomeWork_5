using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnnack : MonoBehaviour
{
    public GameObject bullet_ins;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            
            Bullet b = bullet_ins.GetComponent<Bullet>();
            b.SetEnemy(other.gameObject);

        }
    }
}
