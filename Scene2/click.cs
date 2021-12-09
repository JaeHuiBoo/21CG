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

    [SerializeField]
    private TextMesh numberText;

    [SerializeField]
    private GameObject door;

    public string doorAns;  //answer for the door lock

    // Start is called before the first frame update
    void Start()
    {
        numberText.text = "";
    }

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

                else if(target.tag=="number")
                {
                    if (numberText.text.Length <= 8)
                    {
                        int doorlockNum = Int32.Parse(target.name.Substring(4));
                        numberText.text = numberText.text + doorlockNum.ToString();
                    }
                }

                else if (target.tag == "eraser")
                {
                    if(numberText.text.Length>=0)
                        numberText.text = numberText.text.Substring(0,numberText.text.Length-1);
                }

                else if (target.tag=="enter")
                {
                    numberText.color = Color.red;
                    if (numberText.text == doorAns)
                    {
                        numberText.text = "Success";
                        Invoke("success", 1.3f);
                    }
                    else
                    {
                        numberText.text = "Fail";
                        Invoke("fail", 1.3f);  //delay
                    }
                }
            }
        }
    }
    private void fail()
    {
        numberText.color = Color.black;
        numberText.text = "";
    }
    private void success()
    {
        door.transform.GetComponent<Animation>().Play("doorOpen");
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
