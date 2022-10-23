using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public Collider2D bosscollider;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), bosscollider, false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
