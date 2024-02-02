using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody>();
        }
    }
    public void StartAddForce()
    {
        if (body != null)
        {
            var forceVect = MathUtil.GenerateRandomVector3(1200f);
            body.AddForce(forceVect);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -2f) //ball dropped off from table
        {
            Judge();
            ResetPos();
            ResetSpeed();
        }
    }
    void Judge()
    {
        float posZ = this.transform.position.z;
        string log = "";
        if (posZ > 0)
        {
            log = "right player add 1 point";
        }
        else
        {
            log = "left player add 1 point";
        }
        Debug.Log(log);
    }
    public void ResetPos()
    {

        this.transform.position = new Vector3(0, 0.55f, 0);
    }
    void ResetSpeed()
    {
        body.velocity = Vector3.zero;
    }
}
