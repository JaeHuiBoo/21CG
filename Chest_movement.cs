using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_movement : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.Play("grp_draw_01");
            animator.Play("grp_draw_02");
            animator.Play("grp_draw_03");
            animator.Play("grp_draw_04");
            animator.Play("grp_draw_05");
            animator.Play("grp_draw_06");
            animator.Play("grp_draw_07");
        }
    }
}
