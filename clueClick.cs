using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clueClick : MonoBehaviour
{

    private GameObject target;

    [SerializeField]
    private GameObject cluePanel;

    private List<bool> clueFound = new List<bool>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<cluePanel.transform.childCount;i++)
        {
            clueFound.Add(false);
        }
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
                if (target.tag == "clue")
                {
                    int clueNum = Int32.Parse(target.name.Substring(5));
                    target.SetActive(false);

                    for (int i=0;i< clueFound.Count;i++)
                    {
                        if(!clueFound[i])
                        {
                            cluePanel.transform.GetChild(i).GetComponent<Image>().sprite= Resources.Load<Sprite>("Sprites/"+ SceneManager.GetActiveScene().name +"/clue_" + clueNum) as Sprite;
                            clueFound[i] = true;
                            break;
                        }
                    }
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
