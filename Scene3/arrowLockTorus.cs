using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowLockTorus : MonoBehaviour
{
    //animation 때문에 torus에

    [SerializeField]
    private GameObject arrowLock;

    [SerializeField]
    private GameObject openBlueLock;

    private void openTorus()
    {
        openBlueLock.transform.GetComponent<Animation>().Play("openBlue");
    }
}
