using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float rotateXSpeed = 10.0f;
    public float rotateYSpeed = 10.0f;

    private Vector3 vec = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        vec = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }*/
        Moving();
        Rotating();
    }
    private void Moving()
    {
        vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.transform.Translate(vec);
    }

    private void Rotating()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 rot = this.transform.rotation.eulerAngles; // 현재 카메라의 각도를 Vector3로 반환
            rot.y += Input.GetAxis("Mouse X") * rotateYSpeed; // 마우스 X 위치 * 회전 스피드
            rot.x += Input.GetAxis("Mouse Y") * rotateXSpeed;
            Quaternion q = Quaternion.Euler(rot); // Quaternion으로 변환
            q.z = 0;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // 자연스럽게 회전
        }
    }
}
