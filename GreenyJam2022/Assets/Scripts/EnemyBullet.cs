using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;
    GameObject target;
    private bool hit;

    private void Awake()
    {
        target =GameObject.FindGameObjectWithTag("Player");
       // anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        
        //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*speed);

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position
            , Time.deltaTime * speed);
        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerMovement.WaterCount--;
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("Ground")) {
            Destroy(gameObject);

        }
        //die(); 
    }

}
