using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objects : MonoBehaviour
{
    private GameObject clickedObj;
    private GameObject obj;
    private bool clicking;

    // Start is called before the first frame update
    void Start()
    {
        clickedObj = null;
        obj = null;
        clicking = false;
    }

    // Update is called once per frame
    void Update()
    {
        clickedObj = ClickObject3D();
        if (clickedObj != null)
        {
            if(Input.GetMouseButtonUp(0))
            {
                if (clickedObj.tag == "obj")
                    StartCoroutine(animate(clickedObj.GetComponent<Animator>()));
            }
            else
            {
                if(clickedObj.tag=="obj")
                {
                    obj = clickedObj;
                    obj.GetComponent<Outline>().enabled = true;
                    clicking = true;
                }
                else if(clicking)
                {
                    clicking = false;
                    obj.GetComponent<Outline>().enabled = false;
                    obj = null;
                }
            }
        }
    }

    IEnumerator animate(Animator animator)
    {
        animator.enabled = true;
        yield return new WaitForSeconds(8.0f);
        animator.enabled = false;
    }


    private GameObject ClickObject3D()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
