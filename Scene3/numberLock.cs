using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberLock : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private GameObject backToOriginBtn;

    private GameObject target;

    public bool lookAtNumLock = false;

    [SerializeField]
    private GameObject cluePanel;

    [SerializeField]
    private GameObject lockPanel;

    [SerializeField]
    private GameObject firstGear;

    [SerializeField]
    private GameObject secondGear;

    [SerializeField]
    private GameObject thirdGear;

    [SerializeField]
    private GameObject numLock;

    [SerializeField]
    private GameObject openBlueLock;


    public string userAns="-1";
    public string ans;

    // Start is called before the first frame update
    void Start()
    {
        backToOriginBtn.SetActive(false);
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
                if (target.name == "number_lock" && !lookAtNumLock)
                {
                    backBtn3.originCameraPos = mainCamera.transform.position;
                    backBtn3.originCameraRotation = mainCamera.transform.rotation;
                    mainCamera.transform.position = new Vector3(-17.9f, 12.6f, 46.27f);
                    mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
                    mainCamera.transform.GetComponent<move>().enabled = false;
                    backToOriginBtn.SetActive(true);
                    lookAtNumLock = true;
                    cluePanel.SetActive(false);
                    lockPanel.SetActive(false);
                }
            }
        }

        if (!mainCamera.transform.GetComponent<move>().enabled)
        {
            if (lookAtNumLock)
            {
                userAns = getGearNum(firstGear) + getGearNum(secondGear) + getGearNum(thirdGear);
                if (userAns == ans)
                {
                    numLock.SetActive(false);
                    openBlueLock.transform.GetComponent<Animation>().Play("openBlue");

                    AudioSource audio = openBlueLock.transform.GetComponent<AudioSource>();
                    audio.clip = Resources.Load("Audios/success") as AudioClip;
                    audio.Play();
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




    private string getGearNum(GameObject gear)
    {
        string num="-1";

        float y = gear.transform.eulerAngles.y;

        if (y >= 260 && y <= 277) 
        {
            num = "0";
        }

        else if (y >= 297 && y <= 317)
        {
            num = "1";
        }

        else if (y >= 334 && y <= 351)
        {
            num = "2";
        }

        else if (y >= 11 && y <= 28)
        {
            num = "3";
        }

        else if (y >= 48 && y <= 65)
        {
            num = "4";
        }
        
        else if (y >= 83 && y <= 102)
        {
            num = "5";
        }

        else if (y >= 120 && y <= 139)
        {
            num = "6";
        }

        else if (y >= 154 && y <= 173)
        {
            num = "7";
        }

        else if (y >= 192 && y <= 210)
        {
            num = "8";
        }

        else if (y >= 228 && y <= 247)
        {
            num = "9";
        }
        
        return num;
    }
}

