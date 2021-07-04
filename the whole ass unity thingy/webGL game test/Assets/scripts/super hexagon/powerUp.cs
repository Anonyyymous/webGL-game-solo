using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public int power;
    public GameObject spawner, player;
    public Rigidbody2D rb;
    public float shrinkSpeed = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        power = Random.Range(1, 3);
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(power == 1){
                player.GetComponent<player>().lives += 1;
            } else if(power == 2){
                spawner.GetComponent<spawner>().difficulty += 0.1f;
            }
            
        }
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        if(transform.localScale.x <= 0.01f) {
            Destroy(gameObject);
        }
    }
}
