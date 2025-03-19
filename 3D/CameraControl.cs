using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform Player; // ��Ҷ���
    [SerializeField] private float distance = 3f; // �������ҵľ���
    [SerializeField] private float heightOffset = 1f; // ����ĸ߶�ƫ��
    [SerializeField] private float rotationSpeed = 90f; // �����ת�ٶ�

    private Vector3 initialOffset; // ����������ҵĳ�ʼƫ����

    void Start()
    {
        // ���ó�ʼƫ����
        initialOffset = new Vector3(0, heightOffset, -distance);
    }

    void FixedUpdate()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X");
       

        // ������Ϸ��ĵ���ת���
        transform.RotateAround(Player.position + Vector3.up * heightOffset, Vector3.up, mouseX * rotationSpeed * Time.fixedDeltaTime);

        

        // �����������ҵĹ̶�����
        transform.position = Player.position + Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * initialOffset;
    }
}