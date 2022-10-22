using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float dieTime, damage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        die();
    }

    IEnumerator countDownTimer()
    {
        yield return new WaitForSeconds(dieTime);
        die(); 
    }

    void die()
    {
        Destroy(gameObject);
    }
}
