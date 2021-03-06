﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushback : Effect {
    public override void triggerEffect (GameObject bullet, Collider2D obj, float k) {

        if (obj.transform.name != "Player" && obj.transform.tag != "TriggersToIgnore" && obj.transform.tag != "MapObjects") {
            if (obj.transform.tag != "Map")
                obj.transform.position += bullet.transform.up.normalized * Time.deltaTime * k;
            // obj.position += obj.up.normalized * Time.deltaTime * k;
        }

        //Destroy (bullet);
    }
}