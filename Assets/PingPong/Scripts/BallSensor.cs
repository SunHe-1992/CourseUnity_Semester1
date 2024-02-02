using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSensor : MonoBehaviour
{
    /// <summary>
    /// left=1 right=2
    /// </summary>
    public int id;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        //Debug.Log(this.id + " OnTriggerEnter " + this.gameObject.name);
        PingPongPlay.instance.Scored(this.id);
    }
}
