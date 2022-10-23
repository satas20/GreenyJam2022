using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    public float distance;
    [SerializeField] private float range;
    [SerializeField] private float atackColdown;
    private float cooldownTimer;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;
    private Transform target;
    private Transform player;
    private int health = 2;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight() == false)
        {

            Patrol();
            animator.SetBool("Atack", false);
            animator.SetBool("Insight", false);

        }
        else
        {
            target = player;
            animator.SetBool("Insight", true);

            if (cooldownTimer > atackColdown)
            {
                animator.SetBool("Atack", true);

                //rangedAtack();
                cooldownTimer = 0;
            }
        }

    }
    private void rangedAtack(){
        cooldownTimer = 0;
        GameObject bulletenemy =GameObject.Instantiate(enemyBullet,firePoint.position,Quaternion.identity);
        if (movingRight) {
            bulletenemy.GetComponent<Rigidbody2D>().AddForce(Vector2.right*200);
        }
        else
        {
            bulletenemy.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 200);
        }
    }
    private void Patrol()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range, boxCollider.bounds.size, 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range, boxCollider.bounds.size);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            {
                if(health == 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        //if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        //{
        //    if (movingRight == true)
        //    {
        //        transform.eulerAngles = new Vector3(0, -180, 0);
        //        movingRight = false;
        //    }
        //    else
        //    {
        //        transform.eulerAngles = new Vector3(0, 0, 0);
        //        movingRight = true;
        //    }
        //}
    }
}
