using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    //Animator anim;
    //bool jump = false;
    Animator anim;
    int JumpButtonPressed = Animator.StringToHash("JumpButtonPressed");
    int FireButtonPressed = Animator.StringToHash("FireButtonPressed");
    public float damageTaken;
    float timeLeft = 3.0f;
    // do later var runStateHash : int = Animator.StringToHash("Base Layer.Run");

    void Start()
    {
        //anim = GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();


        //    float horizontalMove = Input.GetAxis("Horizontal");
        //    anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //    anim.SetBool("JumpButonPressed", jump);
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);
        anim.SetFloat("Damage", damageTaken);

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(JumpButtonPressed);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.ResetTrigger(JumpButtonPressed);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger(FireButtonPressed);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            anim.ResetTrigger(FireButtonPressed);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            Damage();
        }
        else if (Input.GetKey(KeyCode.K))
        {
            RepairDamage();
        }

    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(Vector2.up * 10f * Time.deltaTime);
        }
    }

    void Damage()
    {
        if (Input.GetKey(KeyCode.L))
        {
            damageTaken = 1.0f;
        }
    }

    void RepairDamage()
    {
        if (Input.GetKey(KeyCode.K))
        {
            damageTaken = 0.0f;
        }
    }
}
