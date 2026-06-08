using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -15f;
    public float groundStick = -2f;
    public float jumpHeight = 1.5f;   // 跳跃高度（米）

    private CharacterController cc;
    private Vector3 velocity;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    void Update()
    {
        // 水平移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v);
        move = transform.TransformDirection(move);
        move *= speed;

        // 接地检测与重力
        if (cc.isGrounded && velocity.y < 0)
        {
            velocity.y = groundStick;

            // 跳跃输入
            if (Input.GetButtonDown("Jump"))   // 默认空格键
            {
                // 计算初速度：v = sqrt(2 * g * h)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;
        move.y = velocity.y;

        cc.Move(move * Time.deltaTime);
    }
}

