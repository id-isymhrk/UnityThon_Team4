using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private string scene;
    // Start is called before the first frame update
    void Start()
    {
        scene=gameObject.scene.name;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Onclick(){//ボタンによるシーン遷移を管理します(タイトルからゲーム、リザルトからタイトルなど)
        if(scene.Equals("Title Scenes"))SceneManager.LoadScene("Sample Scene");
        else if(scene.Equals("Gameover")||scene.Equals(""))SceneManager.LoadScene("Title Scenes");//clear時のシーン名を書く
    }
    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
