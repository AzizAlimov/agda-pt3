﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Effect {
    public override void triggerEffect (GameObject bullet, Collider2D obj, float timeToDie) {
        effectPrefab = Resources.Load ("Prefabs/Bullets/Explosions") as GameObject;
        if (obj.transform.name != "Player" && obj.transform.tag != "TriggersToIgnore") {
            Debug.Log("Got Here");
            GameObject explosion = Instantiate (effectPrefab, bullet.transform.position, bullet.transform.rotation) as GameObject;
            Debug.Log("Got Here");
            timeToDie = 0f;
            explosion.transform.localScale = new Vector3(3f,3f,1f);
        }
        
        Destroy (bullet, timeToDie);
    }
}