﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartGame(){
        SceneManager.LoadScene("TilemapTestScene");
        foreach (ReloadableGun g in GameObject.FindGameObjectWithTag("Player").transform.GetComponentsInChildren<ReloadableGun>())
        {
            g.Start();
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Start();
        GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.zero;
    }
}
