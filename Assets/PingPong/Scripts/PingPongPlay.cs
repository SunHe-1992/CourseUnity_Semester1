using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PingPongPlay : MonoBehaviour
{
    public SphereController spCtrl;
    public Transform paddle1;
    public Transform paddle2;
    public Transform ball;
    public PaddleController pCtrl1;
    public PaddleController pCtrl2;
    // Start is called before the first frame update
    void Start()
    {
        if (paddle1 == null)
        {
            paddle1 = GameObject.Find("paddle1").transform;
            paddle2 = GameObject.Find("paddle2").transform;
            ball = GameObject.Find("ball").transform;
        }
        if (spCtrl == null)
        {
            spCtrl = ball.gameObject.AddComponent<SphereController>();
        }
        pCtrl1 = paddle1.gameObject.AddComponent<PaddleController>();
        pCtrl2 = paddle2.gameObject.AddComponent<PaddleController>();
        pCtrl1.ResetPos();
        pCtrl2.ResetPos();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }
    
    float sensitivity = 0.1f;
    float input_h;
    float input_v;
    void ReadInput()
    {
        input_h = Input.GetAxis("Horizontal") * sensitivity;
        input_v = Input.GetAxis("Vertical") * sensitivity;
        //Debug.Log($"input = {input_h}, {input_v}");

        if (Input.GetKeyUp(KeyCode.F1))
        {
            spCtrl.StartAddForce();
        }

        pCtrl1.SetXMove(input_h);
        pCtrl2.SetXMove(input_v);
    }
}
