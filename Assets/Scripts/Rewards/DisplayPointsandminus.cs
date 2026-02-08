using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPointsandminus : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text outs;
    public static int points = RewardSystem.Points;
    public  int pointm = Dropdownhand.points;
    void Start()
    {
        outs.SetText(points.ToString());
    }

    // Update is called once per frame
    void Update()
    {

        outs.SetText(pointm.ToString());
    }
}
