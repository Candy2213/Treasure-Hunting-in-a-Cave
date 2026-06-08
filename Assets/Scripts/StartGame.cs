using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject button;

    public void Begin()
    {
        button.SetActive(false);
    }
}