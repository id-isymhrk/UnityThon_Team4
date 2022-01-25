using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class testGameManager : MonoBehaviour
{
    private String scene;
    // Start is called before the first frame update
    void Start()
    {
        scene=gameObject.scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onclick(){
        if(scene.Equals("title"))SceneManager.LoadScene("Scenes/test scenes/result");
        else if(scene.Equals("result"))SceneManager.LoadScene("Audio/title");
    }
}
