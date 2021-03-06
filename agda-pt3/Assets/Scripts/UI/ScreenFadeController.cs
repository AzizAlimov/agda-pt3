﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScreenFadeController : MonoBehaviour
{

    // Fade Out Variables
    public Animator fadeAnim;
    public GameObject fadeImage;
    private string levelToLoad;
    private bool fadeOutComplete;
    private Vector3 spawnLoc;

    private static ScreenFadeController _instance;
    public static ScreenFadeController Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        //DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GameObject.Find("ScreenFade");
        fadeAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeToNewLevel(string levelToOpen, Vector3 locationToSpawn){
        fadeOutComplete = false;
        spawnLoc = locationToSpawn;
        levelToLoad = levelToOpen;
        FadeOut();
        yield return new WaitUntil(()=>fadeOutComplete);
    }
    public void FadeOut(){
        // Fading out...
        fadeAnim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete(){
        Debug.Log("Reached!");
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
        PlayerController.Instance.transform.position = spawnLoc;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().SetCameraPosition(spawnLoc);
        fadeAnim.SetTrigger("FadeIn");
        fadeOutComplete = true;
    }
}
