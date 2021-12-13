using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberLockDrag : MonoBehaviour
{
    private float speed = 3f;
    private GameObject target;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = getTarget3D();
        }

        else if (Input.GetMouseButton(0))
        {
            if(target.tag=="numLockGear")
                target.transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
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
