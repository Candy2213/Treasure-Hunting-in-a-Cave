using UnityEngine;
using TMPro;  // 如果用 TextMeshPro
using UnityEngine.UI; // 如果用旧版 UI，二选一

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;   // 分数显示
    public GameObject winPanel;         // 胜利时显示的面板（UI）
    public int targetScore = 5;         // 需要收集的金币数量

    private int currentScore = 0;
    private bool isGameOver = false;    // 防止胜利后再次触发

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // 确保胜利面板一开始是隐藏的
        if (winPanel != null) winPanel.SetActive(false);
        UpdateUI();
    }

    public void AddScore(int amount)
    {
       // Debug.Log($"AddScore 被调用，增加 {amount}，调用栈：{StackTraceUtility.ExtractStackTrace()}");
        if (isGameOver) return;  // 游戏已结束，不再加分

        currentScore += amount;
        UpdateUI();

        if (currentScore >= targetScore)
        {
            WinGame();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore + " / " + targetScore;
    }

    void WinGame()
    {
        isGameOver = true;
        // 显示胜利面板
        if (winPanel != null) winPanel.SetActive(true);

        // 可选：停止玩家移动
        PlayerMove player = FindObjectOfType<PlayerMove>();
        if (player != null) player.enabled = false;

        // 可选：停止摄像机跟随（如果不需要）
        // CameraFollow cam = FindObjectOfType<CameraFollow>();
        // if (cam != null) cam.enabled = false;

        Debug.Log("You Win! 收集了 " + currentScore + " 个金币。");
    }
  
}
