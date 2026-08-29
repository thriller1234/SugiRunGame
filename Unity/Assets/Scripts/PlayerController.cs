using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float forwardSpeed=5f;
    public float sideSeed=5f;
    public float jumpForce = 7f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        //常に前進
        Vector3 velocity=rb.linearVelocity;
        velocity.z=forwardSpeed;

        //左右移動
        float horizontal=Input.GetAxis("Horizontal");
        velocity.x=horizontal*sideSeed;

        rb.linearVelocity=velocity;

    }

    // Update is called once per frame
    void Update()
    {
        //地面にいるのか確認
        bool isGrounded=Physics.Raycast(
            transform.position,
            Vector3.down,
            1.1f
        );

        //地面にいる時だけ、Spaceキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(
                Vector3.up*jumpForce,
                ForceMode.Impulse
            );
        }
    }
}
