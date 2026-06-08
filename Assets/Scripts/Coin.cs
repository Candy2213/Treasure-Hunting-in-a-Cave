using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    private bool collected = false;

    void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        if (other.CompareTag("Player"))
        {
            collected = true;

            // 加分
            GameManager.Instance.AddScore(value);

            // 让金币立即不可见、不可碰撞
            GetComponent<Collider>().enabled = false;
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if (renderer != null) renderer.enabled = false;

            // 延迟销毁，避免影响其他
            Destroy(gameObject, 0.1f);
        }
    }
}
