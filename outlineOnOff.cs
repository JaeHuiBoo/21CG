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

        else
            this.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {
        this.GetComponent<Outline>().enabled = false;
    }
}

