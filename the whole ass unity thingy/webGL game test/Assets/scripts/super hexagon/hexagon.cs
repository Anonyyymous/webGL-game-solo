using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexagon : MonoBehaviour
{
    public Rigidbody2D rb;
    public float shrinkSpeed = 3f, minSize = 0.5f, maxSize = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * maxSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        if(transform.localScale.x <= minSize) {
            Destroy(gameObject);
        }
    }
}
