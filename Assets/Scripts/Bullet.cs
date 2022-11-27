using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject _enemy;
    public void SetEnemy(GameObject enemy)
    {
        _enemy = enemy;
    }
    private void Update()
    {
        if(_enemy != null )
        {
            gameObject.transform.position =
               Vector3.MoveTowards(transform.position, _enemy.transform.position, 2 * Time.deltaTime);
        }
    }
}
