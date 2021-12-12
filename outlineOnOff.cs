using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlineOnOff : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Outline>().enabled = false;
    }

    private void OnMouseEnter()
    {
        if(this.name=="arrowlock")
        {
            if(!this.transform.GetChild(2).GetComponent<arrowLock>().lookAtArrowLock)
            {
                this.GetComponent<Outline>().enabled = true;
            }
        }

        else if(this.name=="lock")
        {
            if(this.transform.GetComponent<arrowLock>().lookAtArrowLock)
            {
                this.GetComponent<Outline>().enabled = true;
            }
        }

        else if (this.name == "number_lock")
        {
            if (!this.transform.GetComponent<numberLock>().lookAtNumLock)
            {
                this.GetComponent<Outline>().enabled = true;
            }
        }

        else if (this.tag == "numLockGear")
        {
            if (this.transform.parent.GetComponent<numberLock>().lookAtNumLock)
            {
                this.GetComponent<Outline>().enabled = true;
            }
        }

        else if (this.name == "containerBox")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            if (!gameManager.GetComponent<click>().lookAtContainer)
            {
                this.GetComponent<Outline>().enabled = true;
            }
        }

        else if (this.name == "breakerPanel_Model")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            if (!gameManager.GetComponent<click>().lookAtBreaker)
            {
                this.GetComponent<Outline>().enabled = true;
            }
        }

        else if (this.name == "pushNumberLock")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            if (!gameManager.GetComponent<clickScene3>().lookAtPushLock)
            {
                this.GetComponent<Outline>().enabled = true;
            }
        }

        else if (this.name == "radio")
        {
            if (!this.GetComponent<radioManager>().lookAtRadio)
            {
                this.GetComponent<Outline>().enabled = true;
            }
        }

    }

    private void OnMouseExit()
    {
        this.GetComponent<Outline>().enabled = false;
    }
}

