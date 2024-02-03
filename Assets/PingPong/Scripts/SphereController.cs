using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float speed = 25f;
    Rigidbody body;
    ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody>();
            var childTrans = this.transform.Find("CFX4 Magic Hit");
            effect = childTrans.gameObject.GetComponent<ParticleSystem>();

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
        if (Vector3.Distance(this.transform.position, Vector3.zero) > 10f) //ball dropped off from table
        {
            Judge();
            ResetPos();
            StopMoving();
        }

        if (PingPongPlay.instance.phase == GamePhase.DuringGame)
        {
            SetSpeed();
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
    void StopMoving()
    {
        body.velocity = Vector3.zero;
    }
    void SetSpeed()
    {
        if (this.body.velocity.magnitude > 1f)
        {
            this.body.velocity = body.velocity.normalized * speed;
        }
    }
    const float zVelocity = 0.1f;
    const float zVelocityChange = 0.2f;
    private void OnCollisionEnter(Collision collision)
    {
        var rb = body;
        Vector3 reflectVect = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal).normalized;
        //prevent ball keep bouncing vertically
        if (Mathf.Abs(reflectVect.z) < zVelocity)
        {
            if (reflectVect.z >= 0)
                reflectVect.z += zVelocityChange;
            else
                reflectVect.z -= zVelocityChange;
        }
        rb.velocity = reflectVect * speed;

        //random fix direction
        //Vector3 fixVect = (this.transform.position.normalized * 0.1f);
        //fixVect = (reflectVect + fixVect) * speed;
        //fixVect.y = 0;
        //rb.velocity = fixVect;
        PlayEffect();

    }

    void PlayEffect()
    {
        effect.Play();
    }
}
