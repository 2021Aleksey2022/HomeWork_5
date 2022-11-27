using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public bool key;
    public bool xp;
    public float Speed = 0.3f;
    public float JumpForce = 0.5f;

    public LayerMask GroundLayer = 1;

    private Rigidbody _rb;
    private CapsuleCollider _collider;

    private bool IsGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);
            return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.9f, GroundLayer);
        }
    }
    private Vector3 _movementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            return new Vector3(horizontal, 0.0f, vertical);
        }
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        if (GroundLayer == gameObject.layer)
            //Слой сортировки игроков должен отличаться от слоя сортировки земли
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer");
    }
 

    private void FixedUpdate()
    {
        RaycastHit hit;
        Color hitColor;
        Vector3 playerPositin = gameObject.transform.position;
        Vector3 enemyPosition = enemy.transform.position;
        var rayCast = Physics.Raycast(enemyPosition, playerPositin, out hit, Mathf.Infinity);
        if (rayCast)
        {
            hitColor = Color.red;
        }
        else
        {
            hitColor = Color.green;
        }
        Debug.DrawLine(playerPositin, enemyPosition, hitColor);
        JumpLogic();
        MoveLogic();
    }
    private void MoveLogic()
    {
        _rb.AddForce(_movementVector * Speed, ForceMode.Impulse);
    }

    private void JumpLogic()
    {
        if (IsGrounded && (Input.GetAxis("Jump") > 0))
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
  
   
    //Столкновения объектов :
    private void OnTriggerEnter(Collider other)
    {
        //Взрыв бомбы, когда игрок наступает на неё и объект удаляется
        if (other.tag.Equals("Bomb"))
        {
            Debug.Log("Boom!");
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        //открытие двери,
        if (other.tag.Equals("DOOR"))
        {
            if (key)
            {
                Vector3 rotation = other.gameObject.transform.eulerAngles;
                rotation.y = -90;
                other.gameObject.transform.eulerAngles = rotation;
            }
        }
        if (other.tag.Equals("Key"))
        {
            key = true;
            other.gameObject.SetActive(false);
        }
        if (other.tag.Equals("Bullet"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
        if (other.tag.Equals("XP"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
