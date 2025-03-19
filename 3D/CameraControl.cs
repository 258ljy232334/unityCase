using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform Player; // 玩家对象
    [SerializeField] private float distance = 3f; // 相机与玩家的距离
    [SerializeField] private float heightOffset = 1f; // 相机的高度偏移
    [SerializeField] private float rotationSpeed = 90f; // 鼠标旋转速度

    private Vector3 initialOffset; // 相机相对于玩家的初始偏移量

    void Start()
    {
        // 设置初始偏移量
        initialOffset = new Vector3(0, heightOffset, -distance);
    }

    void FixedUpdate()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X");
       

        // 绕玩家上方的点旋转相机
        transform.RotateAround(Player.position + Vector3.up * heightOffset, Vector3.up, mouseX * rotationSpeed * Time.fixedDeltaTime);

        

        // 保持相机与玩家的固定距离
        transform.position = Player.position + Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * initialOffset;
    }
}