using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPlayerScript : MonoBehaviour
{
    public bool key, weapon;
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private List<Asset> _assets;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Vector3 postoin;

    private void Awake()
    {
        _assets= new List<Asset>();
        
    }
    void Update()
    {
        // RaycastHit - точка соприкосновения
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Debug.Log(objectHit.position);
                _meshAgent.destination = hit.point;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Key"))
        {
            other.gameObject.SetActive(false);
            Asset asset = other.gameObject.GetComponent<Asset>();
            _assets.Add(asset);
            key = true;
        }
        if (other.tag.Equals("Gun"))
        {
            other.gameObject.SetActive(false);
            Asset asset = other.gameObject.GetComponent<Asset>();
            _assets.Add(asset);
            weapon = true;
        }
        if (other.tag.Equals("DOOR"))
        {
            if (key)
            {                
                Vector3 rotation = other.gameObject.transform.eulerAngles;
                rotation.y = -90;
                other.gameObject.transform.eulerAngles = rotation;
            }
        }
        if (other.tag.Equals("Gun"))
        {
            if(weapon)
            {
                gameObject.transform.position =
              Vector3.MoveTowards(transform.position, _enemy.transform.position, 2);
               other.gameObject.SetActive(false);
            }
        }
    }
}
   
