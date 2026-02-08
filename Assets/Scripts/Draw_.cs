using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Draw_ : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    public float BrushSize = 0.1f;
    public RenderTexture RTexture;
 

    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    // Update is called once per frame
    void Update()
    {
        Drawing();
    }


    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) )
        {
            CreateBrush();
         
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
       

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }
    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
    void PointToMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }


    public void Save()
    {
        StartCoroutine(CoSave());
    }

    private IEnumerator CoSave()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log(Application.dataPath + "/savedImage.jpg");

        RenderTexture.active = RTexture;

        var texture2D = new Texture2D(RTexture.width, RTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
        texture2D.Apply();

        var data = texture2D.EncodeToJPG();

        File.WriteAllBytes(Application.dataPath + "/savedImage.jpg", data);
    }
  
}
