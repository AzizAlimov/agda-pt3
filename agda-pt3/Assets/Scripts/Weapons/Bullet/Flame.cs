﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : Bullet
{


    void Start()
    {
        bulletSpeed = 0f;
        damageToGive = 1.5f;
    }

    void Update()
    {
        BulletPath(1f);
    }

    public override void BulletPath(float coefficient)
    {
        // transform.position += transform.up.normalized * Time.deltaTime * bulletSpeed * coefficient;
        Destroy(this.gameObject, 0.1f);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        Start();
        if (col.gameObject.GetComponent<Health>() != null)
        {
            col.gameObject.GetComponent<Health>().TakeDamage(damageToGive);
        }
        //Destroy the bullet if it collides with something
        if (col.transform.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}