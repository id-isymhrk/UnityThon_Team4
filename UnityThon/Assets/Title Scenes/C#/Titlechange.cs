using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titlechange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PushStartButton()
    {
        SceneManager.LoadScene("NextScene");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PushStartButton();
        }
    }
}
