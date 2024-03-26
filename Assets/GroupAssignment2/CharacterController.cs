using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{

    Animator animator;
    //Text showText;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //showText = GameObject.Find("Canvas/TextAnim").GetComponent<Text>();
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
        if (Input.GetKey(KeyCode.K))
            animator.SetBool("isCrouch", true);
        else
            animator.SetBool("isCrouch", false);


        float hAxis = Mathf.Abs(Input.GetAxis("Horizontal"));
        if (hAxis > 0.5f)
            animator.SetFloat("speed", hAxis);
        else
            animator.SetFloat("speed", 0);


        //if (showText != null)
        //{
        //     showText.text ="anim = "+ animator.GetCurrentAnimatorClipInfo(0).
        //}
    }
}
