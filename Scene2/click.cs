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
    private GameObject containerDoor;

    public bool lookAtContainer = false;

    [SerializeField]
    private GameObject cluePanel;

    [SerializeField]
    private GameObject backToOriginBtn;

    public string containerUserAns;
    private string containerAns;

    void Start()
    {
        
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

                if (target.name == "containerBox" && !lookAtContainer)
                {
                    backBtn2.originCameraPos = mainCamera.transform.position;
                    backBtn2.originCameraRotation = mainCamera.transform.rotation;
                    mainCamera.transform.position = new Vector3(11.1f, 14.7f, -31.8f);
                    mainCamera.transform.rotation = Quaternion.Euler(0, 180, 0);
                    mainCamera.transform.GetComponent<move>().enabled = false;
                    backToOriginBtn.SetActive(true);
                    lookAtContainer = true;
                    cluePanel.SetActive(false);
                }
                
            }
        }

        if(lookAtContainer)
        {
            if (containerUserAns == containerAns)
            {
                containerDoor.GetComponent<Animation>().Play();
                containerDoor.GetComponent<AudioSource>().Play();
                containerUserAns = "";
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
