using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Transform[] _goal;
    [SerializeField] private int _index;

    private void Start()
    {
        //������������ � ������������ ����� ������ � ������� NavMeshAgent
        _meshAgent.destination = _goal[_index].position;
    }
    private void Update()
    {
        //�������� ������ � ������� �������� distance
        float distance = Vector3.Distance(gameObject.transform.position, _goal[_index].position);
        if (distance < 1f)
        {
            _index += 1;
            if (_index > _goal.Length - 1)
            {
                _index = 0;
            }
            _meshAgent.destination = _goal[_index].position;
        }  
    }
}
