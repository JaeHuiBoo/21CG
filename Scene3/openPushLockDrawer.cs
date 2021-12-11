using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPushLockDrawer : MonoBehaviour
{
    [SerializeField]
    private GameObject drawer_1;

    private void openTorus()
    {
        drawer_1.transform.GetComponent<Animation>().Play("drawerOpen");
    }
}
