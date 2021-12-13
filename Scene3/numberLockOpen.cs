using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberLockOpen : MonoBehaviour
{

    [SerializeField]
    private GameObject numberLock;

    [SerializeField]
    private GameObject openBlueLock;

    private void openNumLock()
    {
        numberLock.SetActive(false);
        openBlueLock.transform.GetComponent<Animation>().Play("openBlue");

        AudioSource audio = openBlueLock.transform.GetComponent<AudioSource>();
        audio.clip = Resources.Load("Audios/success") as AudioClip;
        audio.Play();
    }
}
