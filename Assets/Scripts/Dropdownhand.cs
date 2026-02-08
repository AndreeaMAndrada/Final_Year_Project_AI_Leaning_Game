using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dropdownhand : MonoBehaviour
{
    public TextMeshProUGUI output;
    public TMP_Text outs;
    public string[] text;
    public static int points = RewardSystem.Points;
    

    public void HandleIndata(int val)
    {
        if (val == 0)
        {
            
            output.text = text[0];
            points--;
        }
        if (val == 1)
        {
            
            output.text = text[1];
            points--;
        }
        if (val == 2)
        {
          
            output.text = text[2];
            points--;
        }
    }

    private void Start()
    {
        points = RewardSystem.Points;
    }
    private void Update()
    {
        outs.SetText(points.ToString());
        if (points == 0)
        {
            SceneManager.LoadScene("Scene2");
            points = 0;
            
            
        }
    }
}
