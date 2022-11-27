using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public bool key;
    public bool xp;
    public float speed = 10f;
    public float Hspeed = 10f;
    void Start()
    {
        //Vector3 posinion = gameObject.transform.position;       
        //узанём дистанцию от игрока до врага :
        //float distance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);
        //Debug.Log(distance);

        //тупорылое вращение, которое не работает
        //Vector3 direction = enemy.transform.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //transform.rotation = rotation;       
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
    }
    void Update()
    {
        //Передвижение игрока по оси X :
        //if(Input.GetKey(KeyCode.W))
        // {
        //     Vector3 posinion = gameObject.transform.position;
        //     posinion.x += 0.01f;
        //     gameObject.transform.position = posinion;
        // }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -Hspeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime  * Hspeed);
        }
        //if(Input.GetKeyDown(KeyCode.Space) && ground) 
        //{
        //    ground = false;
        //    GetComponent<Rigidbody>().AddForce(new Vector3(0, 300, 0));
        //}

        //if (Input.GetKey(KeyCode.W))
        //{
        //    gameObject.transform.position =
        //        Vector3.MoveTowards(transform.position, enemy.transform.position, 2 * Time.deltaTime);
        //}

        //Вращение игрока :
        // transform.Rotate(Vector3.up * Time.deltaTime);

        //transform.LookAt(enemy.transform);
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

    //private void OnCollisionEnter(Collision other)
    //{
    //    if(other.tag.E)
    //    Debug.Log("Yit");
    //}
}
