using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float range,Walkspeed,TimeBTWShot,shootSpeed;
    public Transform player,shootPos;
    private float distToPlayer;
    private bool MustPatrol,canShoot;
    public Rigidbody2D rb;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        MustPatrol = true;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x>0)
            {
                flip();
            }
            MustPatrol = false;
            rb.velocity = Vector2.zero;
            if (canShoot)
            {

            }
            StartCoroutine(Shoot());    
        }
        else
        {
            MustPatrol = true;
        }
    }
    void flip()
    {
        MustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        Walkspeed *= -1;
        MustPatrol = true;
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(TimeBTWShot);
        GameObject newBullet = Instantiate(Bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed*Walkspeed*Time.fixedDeltaTime,0f);
        canShoot = true;

    }
}
