﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    // Basic Player Gun class that is attached to a gun object

    [RangeAttribute(0,1)]
    public float timeBetweenShots;
    private float intervalBullet;   //The interval time until the next bullet can be fired
    private int shotsQueued; // The amount of shots queued after the current cooldown
    public Transform muzzle;   // Location of the muzzle of the gun
    GameObject bulletPrefab;
    


    void Start()
    {
        //Loads bullet prefab
        bulletPrefab = Resources.Load("Prefabs/Bullet/PlayerBullet") as GameObject;
    }

    // Fires the player's gun if Left Mouse-Button is pressed
    public void FireGun() {
        intervalBullet -= Time.deltaTime;
        if (intervalBullet <= 0 && (shotsQueued > 0 || Input.GetMouseButton(0))) {//if player clicks left mouse or there is a bullet queued
            intervalBullet = timeBetweenShots; // Sets the time between bullets to timeBetweenShots
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            if(shotsQueued > 0){
                shotsQueued--;
            } else {
                shotsQueued = 0;
            }
        } else if(Input.GetMouseButtonDown(0)){
            shotsQueued++;
        }
    }

}
