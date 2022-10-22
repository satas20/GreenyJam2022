using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDamage : MonoBehaviour
{
    [SerializeField] GameObject rainD;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RainDam());
    }

    IEnumerator RainDam()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector2(wanted, transform.position.y);
            GameObject gameObject = Instantiate(rainD, position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
