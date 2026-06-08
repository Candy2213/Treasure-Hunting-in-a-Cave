using UnityEngine;
using Cinemachine;

public class CutsceneManager : MonoBehaviour
{
    public CameraFollow cameraFollowScript;  // 拖入 Main Camera 上的 CameraFollow 脚本

    // 这个方法就是“动画结束时要做的事”
    public void OnCutsceneEnd()
    {
        // 禁用 CinemachineBrain，让它不再控制摄像机
        CinemachineBrain brain = Camera.main.GetComponent<CinemachineBrain>();
        if (brain != null) brain.enabled = false;

        // 启用你的第三人称跟随脚本
        if (cameraFollowScript != null) cameraFollowScript.enabled = true;

        Debug.Log("动画结束，切换到跟随视角");
    }
}