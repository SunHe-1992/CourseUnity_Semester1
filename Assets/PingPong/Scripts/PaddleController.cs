using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    float xMax = 3;
    float xMin = -3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetXMove(float value)
    {
        var vect = this.transform.position;
        vect.x += value;
        if (vect.x < xMin) vect.x = xMin;
        if (vect.x > xMax) vect.x = xMax;
        this.transform.position = vect;
    }
    public void ResetPos()
    {
        var vect = this.transform.position;
        vect.x = 0;
        this.transform.position = vect;
    }
}
