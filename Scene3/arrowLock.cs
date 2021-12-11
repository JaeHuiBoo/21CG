using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowLock : MonoBehaviour
{
    //animation 때문에 lock에

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private GameObject arrowLockBoll;

    [SerializeField]
    private GameObject arrowLockTorus;

    [SerializeField]
    private GameObject backToOriginButton;

    [SerializeField]
    private GameObject cluePanel;

    [SerializeField]
    private GameObject lockPanel;

    private GameObject target;

    public bool lookAtArrowLock=false;

    public string ans;
    public string userAns;   

    // Start is called before the first frame update
    void Start()
    {
        backToOriginButton.SetActive(false);
        userAns = "";
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
                if (target.name == "arrowlock" && !lookAtArrowLock)
                {
                    backBtn3.originCameraPos = mainCamera.transform.position;
                    backBtn3.originCameraRotation = mainCamera.transform.rotation;
                    mainCamera.transform.position = new Vector3(-3.53f, 12.75f, 39.42f);
                    mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
                    mainCamera.transform.GetComponent<move>().enabled = false;
                    backToOriginButton.SetActive(true);
                    lookAtArrowLock = true;
                    cluePanel.SetActive(false);
                    lockPanel.SetActive(false);
                }

                else if (target.name == "lock")
                {
                    userAns = "";
                }
                
            }           

        }

        if (!mainCamera.transform.GetComponent<move>().enabled)
        {
            if (lookAtArrowLock)
            {
                Animation anim = arrowLockBoll.transform.GetComponent<Animation>();
                Animator animator = arrowLockBoll.transform.GetComponent<Animator>();
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    anim.Play("leftArrowLock");
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    anim.Play("rightArrowLock");
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    anim.Play("upArrowLock");
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    anim.Play("downArrowLock");
                }

                if (userAns == ans)
                {
                    arrowLockTorus.GetComponent<Animation>().Play("openTorus");
                    userAns = "";
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
    
    private void addAnsLeft()
    {
        userAns += "L";
    }

    private void addAnsRight()
    {
        userAns += "R";
    }

    private void addAnsUp()
    {
        userAns += "U";
    }

    private void addAnsDown()
    {
        userAns += "D";
    }


}
