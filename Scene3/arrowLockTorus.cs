using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowLockTorus : MonoBehaviour
{
    //animation ������ torus��

    [SerializeField]
    private GameObject arrowLock;

    [SerializeField]
    private GameObject openBlueLock;

    private void openTorus()
    {
        openBlueLock.transform.GetComponent<Animation>().Play("openBlue");
    }
}
