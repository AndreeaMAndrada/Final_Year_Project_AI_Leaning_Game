using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SwitchScenes : MonoBehaviour
{
    SavePlayerPos playerPosData;

    void Start()
    {
        
        playerPosData = FindObjectOfType<SavePlayerPos>();
    }
   
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
        playerPosData.PlayerPosSave();
    }
   

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey("space") )//the button to be pressed 
            { 
            SceneManager.LoadScene("SampleScene"); //write what scene to be loaded
        }
    }*/
}
