﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerBehavior : MonoBehaviour {
    public float health;
    public GameObject healthBar;
    float totalHealth;
	// Use this for initialization
	void Start () {
        health = 100;
        totalHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
        updateHealth(healthBar);
		Debug.Log (health);
	}

    void updateHealth(GameObject healthBar)
    {
        healthBar.transform.localScale = new Vector3(health/totalHealth, transform.localScale.y,transform.localScale.z);
    }
    public void takeDamage(float damage)
    {
        health -= damage;
    }
}
