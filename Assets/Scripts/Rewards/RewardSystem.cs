using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RewardSystem : MonoBehaviour
{
    public static int Points = 0;
  
    public TMP_Text outs;
    public int change = Dropdownhand.points;
    

public void Pointup()
    {
           Points++;
      
    }
    private void Update()
    {
        outs.SetText(Points.ToString());
        if (change != Points && change > 0)
        {
            Points = change;
        }

    }
    private void Start()
    {
       

    }

}
