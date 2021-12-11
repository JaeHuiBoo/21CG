using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click : MonoBehaviour
{
    private GameObject target;
    private List<bool> drawerFlag= new List<bool>() {false,false,false, false, false, false, false };

    [SerializeField]
    private Camera mainCamera;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = getTarget3D();
        }

        if (target != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (target.tag == "drawer")
                {
                    int drawerNum = Int32.Parse(target.name.Substring(7));
                    if (!drawerFlag[drawerNum])  //close -> open
                    {
                        if (drawerNum >= 3)   //big drawer
                        {
                            target.GetComponent<Animation>().Play("drawer2Open");
                        }
                        else  //small drawer
                        {
                            target.GetComponent<Animation>().Play("drawerOpen");
                        }
                        drawerFlag[drawerNum] = true;
                    }
                    else   //open -> close
                    {
                        if (drawerNum >= 3)   //big drawer
                        {
                            target.GetComponent<Animation>().Play("drawer2Close");
                        }
                        else  //small drawer
                        {
                            target.GetComponent<Animation>().Play("drawerClose");
                        }
                        drawerFlag[drawerNum] = false;
                    }
                }

                if (target.name == "containerBox")
                {

                }


            }
        }
    }

    private GameObject getTarget3D()
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}
