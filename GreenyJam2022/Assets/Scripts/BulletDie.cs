using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{
    public float dieTime;
    public GameObject Water;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name != "Player")
        {
            Die();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }
   void Die()
    {
        GameObject NewWater = Instantiate(Water, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
