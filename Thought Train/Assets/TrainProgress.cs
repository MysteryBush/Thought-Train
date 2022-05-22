using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainProgress : MonoBehaviour
{
    //UI
    public Slider trainSlider;
    //Train distance value
    public float trainDistance = 0;
    public float goalDistance = 100;

    public float trainSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trainDistance <= goalDistance)
        {
            trainDistance += trainSpeed * Time.deltaTime;

            trainSlider.value = trainDistance;
        }

        if (trainDistance >= goalDistance)
        {
            Debug.Log("GAME OVER");
        }
    }
}
