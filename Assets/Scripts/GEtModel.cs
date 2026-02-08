using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;
using System.Linq;
using System;

public class GEtModel : MonoBehaviour
{
    public Texture2D texture;

    public NNModel modelAsset;

    private Model _runtimeModel;

    private IWorker _engine;
   // public int predictedValue;

    [Serializable]
    public struct Prediction
    {
        public int predictedValue;
        public float[] predicted;

        public void SetPrediction(Tensor t)
        {
            predicted = t.AsFloats();
            predictedValue = Array.IndexOf(predicted, predicted.Max());
            Debug.Log($"Predicted{ predictedValue}");// check here

            if (predictedValue == 0)
            {
                Debug.Log("a");
            }
            if (predictedValue == 1)
            {
                Debug.Log("e");
            }
            if (predictedValue == 2)
            {
                Debug.Log("i");
            }
            if (predictedValue == 3)
            {
                Debug.Log("o");
            }
            if (predictedValue == 4)
            {
                Debug.Log("u");
            }

        }

    }

    public Prediction prediction;
   
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
           
          // predictedValue = Array.IndexOf(prediction, prediction.Max());
           // Debug.Log(prediction);

        }
    }

    private void OnDestroy()
    {
        _engine?.Dispose();
    }
}
