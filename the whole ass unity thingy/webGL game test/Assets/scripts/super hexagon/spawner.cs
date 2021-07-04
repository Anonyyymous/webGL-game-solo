using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public float spawnRate = 1f;
    public GameObject hexagon;
    private float timeToSpawn = 0f;
    public float difficulty = 0f, highscore = 0f;
    public bool spawn;
    public Text score, highscoretxt;
    public GameObject buttonObj, pauseMenu; //pause menu means the pause button
    public ParticleSystem deathPar;

    void Start(){
        spawn = false;
        if(highscore <= 0){
            highscoretxt.text = "high score: 0";
            score.text = "current score: 0";
        }
        pauseMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToSpawn && spawn){
            Instantiate(hexagon, Vector3.zero, Quaternion.identity);
            timeToSpawn = Time.time + (1f / (spawnRate + difficulty));
            difficulty += 0.01f;
            score.text = "current score: " + (Mathf.Round(difficulty * 1000)).ToString();
        }
    }
    public void death(){
        spawn = false;
        if(difficulty >= highscore){
            highscore = difficulty;
        }
        highscoretxt.text = "high score: " + (Mathf.Round(highscore * 1000)).ToString();
        buttonObj.SetActive(true);
        if(spawn){
            deathPar.Play();
        }
        pauseMenu.SetActive(false);
    }

    public void StartGame(){
        spawn = true;
        difficulty = 0f;
        buttonObj.SetActive(false);
        pauseMenu.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D c){
        if(c.tag == "hexagon" && spawn == false){
            GameObject obj = c.GetComponent<GameObject>(); //doesnt really do anything
            Destroy(obj);
        }
    }
}
