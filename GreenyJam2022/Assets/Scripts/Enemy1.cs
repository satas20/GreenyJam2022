using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    private bool movingRight=true;
    public Transform groundDetection;
    public float distance;
    [SerializeField] private float range;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private  BoxCollider2D boxCollider;
    // Start is called before the first frame update
    private float coolDownTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInSight() ==false) { Patrol();}
        else { Debug.Log(PlayerInSight()); }

    }
    private void Patrol() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, distance);

        if (groundInfo.collider == false )
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
    private bool PlayerInSight(){
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center+transform.right * range, boxCollider.bounds.size, 0, Vector2.left,0,playerLayer);
        return hit.collider!=null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+ transform.right * range, boxCollider.bounds.size);
    }
}
