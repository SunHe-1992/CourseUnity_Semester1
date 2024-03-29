using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetBool("isJump", true);
        if (Input.GetKeyUp(KeyCode.Space))
            animator.SetBool("isJump", false);

        if (Input.GetKeyDown(KeyCode.J))
            animator.SetBool("isAttack", true);
        if (Input.GetKeyUp(KeyCode.J))
            animator.SetBool("isAttack", false);


        float hAxis = Mathf.Abs(Input.GetAxis("Horizontal"));
        if (hAxis > 0.5f)
            animator.SetFloat("speed", hAxis);
        else
            animator.SetFloat("speed", 0);

    }
}
