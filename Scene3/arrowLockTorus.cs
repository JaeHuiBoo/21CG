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
        arrowLock.SetActive(false);
        openBlueLock.transform.GetComponent<Animation>().Play("openBlue");

        AudioSource audio = openBlueLock.transform.GetComponent<AudioSource>();
        audio.clip = Resources.Load("Audios/success") as AudioClip;
        audio.Play();
    }
}
