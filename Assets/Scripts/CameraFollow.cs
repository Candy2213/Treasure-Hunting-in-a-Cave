using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // 角色
    public float distance = 3f;        // 距离
    public float height = 2f;          // 高度偏移
    public float smoothSpeed = 5f;     // 跟随平滑度

    // 旋转相关
    public float mouseSensitivity = 2f; // 鼠标灵敏度
    private float currentX = 0f;       // 当前水平角度
    private float currentY = 20f;      // 当前俯仰角度（初始20度，向下看一点）

    public float minY = -20f;          // 向下最小角度（防止转到地下）
    public float maxY = 60f;           // 向上最大角度

    void LateUpdate()
    {
        if (target == null) return;

        // 获取鼠标输入
        currentX += Input.GetAxis("Mouse X") * mouseSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        currentY = Mathf.Clamp(currentY, minY, maxY);

        // 计算摄像机的位置：围绕角色旋转
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position + rotation * new Vector3(0, height, -distance);

        // 平滑移动
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // 让摄像机看向角色（或者看向角色上方一点）
        Vector3 lookTarget = target.position + Vector3.up * (height * 0.5f);
        transform.LookAt(lookTarget);
    }
}