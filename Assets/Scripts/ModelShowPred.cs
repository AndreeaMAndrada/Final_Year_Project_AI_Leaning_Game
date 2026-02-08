using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class ModelShowPred : MonoBehaviour
{
    public Texture2D texture;

    public NNModel modelAsset;

    private Model _runtimeModel;

    private IWorker _engine;

    public static string text;
    public Text pred;

    [Serializable]
    public struct Prediction
    {
        public int predictedValue;
        public float[] predicted;
        public static int spred;

        public void SetPrediction(Tensor t)
        {
            predicted = t.AsFloats();
            predictedValue = Array.IndexOf(predicted, predicted.Max());
           // Debug.Log($"Predicted{ predictedValue}");// check here
                                                     // pred.text = predictedValue.ToString();
            spred = predictedValue;
            Debug.Log(spred);
    }

       
    }

    public Prediction prediction;
    // Start is called before the first frame update
    void Start()
    {
        _runtimeModel = ModelLoader.Load(modelAsset);
        _engine = WorkerFactory.CreateWorker(_runtimeModel, WorkerFactory.Device.GPU);
        prediction = new Prediction();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //how the mnist data gets info
            var channelCount = 3; //grayscale, 3=color, 4=color+alpha
            var inputX = new Tensor(texture, channelCount);

            Tensor outputY = _engine.Execute(inputX).PeekOutput();
            inputX.Dispose();
            prediction.SetPrediction(outputY);
           
          // Debug.Log(spred);// check her
        }
       // pred.text = text.ToString();
      
    }

    private void OnDestroy()
    {
        _engine?.Dispose();
    }
}
