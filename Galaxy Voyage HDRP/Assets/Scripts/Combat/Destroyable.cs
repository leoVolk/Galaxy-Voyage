﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public float maxHealth;

    public ParticleSystem destroyEffect;

    private float health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage){
        health -= damage;

        if(health <= 0){
            Destroy();
        }

        health = Mathf.Clamp(health, 0, maxHealth);
    }

    void Destroy(){
        if(destroyEffect != null){
            GameObject g = Instantiate(destroyEffect,transform.position, Quaternion.identity).gameObject;
            g.transform.localScale = transform.localScale;
            Destroy(g, 2f);
        }

        Destroy(this.gameObject);
    }
}
