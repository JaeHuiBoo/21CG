using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorNumLock : MonoBehaviour
{

    public string doorAns;  //answer for the door lock
    public string elecAns;  
    public string containerAns;


    [SerializeField]
    private TextMesh doorNumText;

    [SerializeField]
    private TextMesh elecNumText;

    [SerializeField]
    private TextMesh containerNumText;

    [SerializeField]
    private GameObject electronic;
    

    [SerializeField]
    private GameObject mainCamera;

    private GameObject target;
    private TextMesh selectedText;

    private int mode = 0;
    

    void Start()
    {
        doorNumText.text = "";
        elecNumText.text = "";
        containerNumText.text = "";
    }

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
                if (target.tag == "number")
                {
                    if (target.transform.parent.parent.name == "goOutDoor")
                    {
                        mode = 1;
                        if (doorNumText.text.Length <= 8)
                        {
                            int num = System.Int32.Parse(target.name.Substring(4));
                            doorNumText.text = doorNumText.text + num.ToString();
                        }
                    }

                    else if (target.transform.parent.parent.name == "BreakerPanelDoor")
                    {
                        mode = 2;
                        if (elecNumText.text.Length <= 8)
                        {
                            int num = System.Int32.Parse(target.name.Substring(4));
                            elecNumText.text = elecNumText.text + num.ToString();
                        }
                    }

                    else if (target.transform.parent.parent.name == "containerDoor")
                    {
                        mode = 3;
                        if (containerNumText.text.Length <= 8)
                        {
                            int num = System.Int32.Parse(target.name.Substring(4));
                            containerNumText.text = containerNumText.text + num.ToString();
                        }
                    }

                }


                else if (target.tag == "eraser")
                {
                    if (mode == 1)
                    {
                        if (doorNumText.text.Length > 0)
                            doorNumText.text = doorNumText.text.Substring(0, doorNumText.text.Length - 1);
                    }

                    else if (mode == 2)
                    {
                        if (elecNumText.text.Length > 0)
                            elecNumText.text = elecNumText.text.Substring(0, elecNumText.text.Length - 1);
                    }

                    else if (mode == 3)
                    {
                        if (containerNumText.text.Length > 0)
                            containerNumText.text = containerNumText.text.Substring(0, containerNumText.text.Length - 1);
                    }
                }

                else if (target.tag == "enter")
                {
                    if (target.transform.parent.parent.name == "goOutDoor" || mode == 1)
                    {
                        doorNumText.color = Color.red;
                        if (doorNumText.text == doorAns)
                        {
                            doorNumText.text = "Success";
                            Invoke("success", 1.3f);
                        }
                        else
                        {
                            doorNumText.text = "Fail";
                            Invoke("fail", 1.3f);  //delay
                        }
                    }

                    else if (target.transform.parent.parent.name == "BreakerPanelDoor"||mode==2)
                    {
                        elecNumText.color = Color.red;
                        if (elecNumText.text == elecAns)
                        {
                            elecNumText.text = "Success";
                            Invoke("success", 1.3f);
                        }
                        else
                        {
                            elecNumText.text = "Fail";
                            Invoke("fail", 1.3f);  //delay
                        }
                    }

                    else if (target.transform.parent.parent.name == "containerDoor"||mode==3)
                    {
                        containerNumText.color = Color.red;
                        if (containerNumText.text == containerAns)
                        {
                            containerNumText.text = "Success";
                            Invoke("success", 1.3f);
                        }
                        else
                        {
                            containerNumText.text = "Fail";
                            Invoke("fail", 1.3f);  //delay
                        }
                    }


                }
            }
        }
        
    }
    private void fail()
    {
        if (mode==1)
        {
            doorNumText.color = Color.black;
            doorNumText.text = "";
        }

        else if (mode == 2)
        {
            elecNumText.color = Color.black;
            elecNumText.text = "";
        }

        else if (mode == 3)
        {
            containerNumText.color = Color.black;
            containerNumText.text = "";
        }
    }


    private void success()
    {
        

        if (mode==2)
        {
            electronic.transform.GetComponent<Animation>().Play();
            electronic.transform.GetComponent<AudioSource>().Play();
        }

        else
            target.transform.parent.parent.GetComponent<Animation>().Play();

        /*
        if(this.name== "goOutDoor")
            this.transform.GetComponent<Animation>().Play("goOutDoor");

        else if(this.name== "BreakerPanelDoor")
            this.transform.GetComponent<Animation>().Play("breakerPanelOpen");
            */
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
