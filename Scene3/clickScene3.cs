using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class clickScene3 : MonoBehaviour
{
    private GameObject target;
    private List<bool> drawerFlag = new List<bool>() { false, false, false, false, false, false };

    private List<bool> lockFlag = new List<bool>() { false, false, false, false, false, false, false, false };

    public bool lookAtPushLock = false;

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private GameObject backToOriginBtn;

    [SerializeField]
    private GameObject cluePanel;

    [SerializeField]
    private GameObject lockPanel;

    [SerializeField]
    private GameObject pushNumTorus;

    public List<string> userAnswers = new List<string>();
    public List<string> ans = new List<string>();

    // Start is called before the first frame update
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
                        target.GetComponent<Animation>().Play("drawerOpen");
                        drawerFlag[drawerNum] = true;
                    }
                    else   //open -> close
                    {
                        target.GetComponent<Animation>().Play("drawerClose");
                        drawerFlag[drawerNum] = false;
                    }
                }

                else if (target.name=="pushNumberLock" && !lookAtPushLock)
                {
                    backBtn3.originCameraPos = mainCamera.transform.position;
                    backBtn3.originCameraRotation = mainCamera.transform.rotation;
                    mainCamera.transform.position = new Vector3(-41.03f, 2.93f, -50.23f);
                    mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
                    mainCamera.transform.GetComponent<move>().enabled = false;
                    backToOriginBtn.SetActive(true);
                    lookAtPushLock = true;
                    cluePanel.SetActive(false);
                    lockPanel.SetActive(false);
                }

                else if (target.tag == "pushNum")
                {
                    int lockNum = Int32.Parse(target.name.Substring(5));
                    if (!lockFlag[lockNum])  
                    {
                        lockFlag[lockNum] = true;
                        userAnswers.Add(lockNum.ToString());
                        userAnswers.Sort();
                        target.transform.GetComponent<MeshRenderer>().material = Resources.Load("Materials/red_mat") as Material;
                    }
                    else
                    {
                        lockFlag[lockNum] = false;
                        int idx = userAnswers.FindIndex(a => a.Contains(lockNum.ToString()));
                        userAnswers.RemoveAt(idx);
                        target.transform.GetComponent<MeshRenderer>().material = Resources.Load("Materials/cube") as Material;
                    }
                }
            }
        }


        if(userAnswers.SequenceEqual(ans))
        {
            pushNumTorus.transform.GetComponent<Animation>().Play();
            userAnswers.RemoveRange(0, ans.Count - 1);
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
