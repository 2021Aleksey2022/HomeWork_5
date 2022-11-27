using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bullet_hole_1;
    [SerializeField] private Transform _bullet_hole_2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameObject bullet_ins = Instantiate(_bullet, _bullet_hole_1.position, Quaternion.identity);
            Bullet b = bullet_ins.GetComponent<Bullet>();
            b.SetEnemy(other.gameObject);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        transform.LookAt(other.gameObject.transform);
    }
}
