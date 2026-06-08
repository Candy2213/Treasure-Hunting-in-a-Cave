using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject startButton;

    void Start()
    {
        startButton.SetActive(false);

    }

    public void ShowButton()
    {
        startButton.SetActive(true);
    }

    public void Begin()
    {
        startButton.SetActive(false);

        // 进入游戏
        // 启用玩家移动脚本
        PlayerMove pm = FindObjectOfType<PlayerMove>();
        if (pm != null) pm.enabled = true;
    }
}