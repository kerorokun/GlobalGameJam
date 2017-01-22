﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] objects;
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime;            // How long between each spawn
	public int numberMultiplierPerWave;
	public Transform[] spawnPoints;
    public GameObject HUD;
    public Text text;
    public GameObject player;
    public bool running;
	private int waveNumber = 0;
    public bool menuOn;
    public GameObject startButton;

	// Use this for initialization
	void Start () {
        text.GetComponent<Text>();
        running = false;
        HUD.SetActive(false);
        goToMenu();
		SpawnRandom ();
		InvokeRepeating ("SpawnRandom", spawnTime, spawnTime);
    }

	public void SpawnRandom()
	{
		if (running) {
			waveNumber++;
			
			//displayes waveNumbers to face
			StartCoroutine(displayWaveNumber(waveNumber));
			
			
			for (int i = 0; i < waveNumber * numberMultiplierPerWave; i++) {
				int spawnPointIndex = Random.Range (0, spawnPoints.Length);
				Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			}
		}

	}

    IEnumerator stall(int secs)
    {
       
        yield return new WaitForSeconds(3);
        

    }

    IEnumerator displayWaveNumber(int waveNumber)
    {
        text.text = "Wave " + waveNumber;
        HUD.SetActive(true);
        yield return new WaitForSeconds(3);
        HUD.SetActive(false);
        
    }

    public void startGame()
    {
        running = true;
        menuOn = false;
        startButton.SetActive(menuOn);
    }

    public void goToMenu()
    {
        running = false;
        menuOn = true;
        startButton.SetActive(menuOn);
    }
	
	
	// Update is called once per frame
	void Update () {
		float health = player.GetComponent<playerBehavior>().health;
        if(health < 1)
        {
            running = false;
        }

        if(running == false)
        {
            text.text = "GAME OVER";
            HUD.SetActive(true);
            StartCoroutine(stall(3));
            HUD.SetActive(false);
            goToMenu();
        }

    }
}
