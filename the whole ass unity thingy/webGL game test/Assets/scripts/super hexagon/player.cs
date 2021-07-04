using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float moveSpeed = 600f;
    float movement = 0f;
    public int lives = 3;
    public Text life;
    public GameObject spawner;
    public ParticleSystem damaged;

    void Start(){
        lives = 3;
        life.text = "lives remaining: " + lives.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("click");
        }
    }

    private void FixedUpdate(){
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D c){
        if(c.tag == "hexagon"){
            if(lives >= 1){
                lives -= 1;
                damaged.Play();
            }
            Destroy(c.gameObject);
            life.text = "lives remaining: " + lives.ToString();
            if(lives <= 0){
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                spawner.GetComponent<spawner>().death();
            }
        }

    }
    public void newGame(){
        lives = 3;
        life.text = "lives remaining: " + lives.ToString();
    }
}
