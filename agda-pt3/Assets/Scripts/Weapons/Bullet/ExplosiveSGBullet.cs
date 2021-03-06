﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveSGBullet : Bullet {
    // Start is called before the first frame update

    void Start () {
        bulletSpeed = 70f;
        damageToGive = 1.667f;
        effect = this.gameObject.AddComponent<Explosion>();
        timeToDie = 1.0f;
    }

    void Update () {
        BulletPath (1f);
    }

    public override void BulletPath (float coefficient) {
        transform.position += transform.up.normalized * Time.deltaTime * bulletSpeed * coefficient;
        Destroy (this.gameObject, 0.8f);
    }

    public override void OnTriggerEnter2D (Collider2D col) {
        Start (); // Added in case OnTriggerEnter2D is called before start is called
        if (col.gameObject.GetComponent<ZombieEnemyController> ()) {
            Physics2D.IgnoreCollision (col.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
        }
        if (col.gameObject.tag == "Enemy") {
            col.gameObject.GetComponent<Health> ().TakeDamage (damageToGive);
        }
        effect.triggerEffect(this.gameObject, col, 3f);
        if (col.transform.name != "Player" && col.transform.tag != "TriggersToIgnore") {
            Destroy(this.gameObject);
        }
    }
}