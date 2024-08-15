using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    //--- Khai báo chuyển động animation
    private SpriteRenderer sprite;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    //--- Hộp của nền Terrian
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling}

    [SerializeField] private AudioSource jumppingSound;
    // Start is called before the first frame update
    private void Start()
    {
        //--- Tạo một component để gọi chung
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //--- GetAxis sẽ làm cho chuyển động giảm từ từ khi ta dừng.
        //--- Horizontal là gọi từ Project Setting -> Input Manager để lấy di chuyển
        //--- driX chỉ cho tốc độ di chuyển nếu âm thì lùi, dương thì tiến
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        //--- Điều kiện nhảy: Nếu khi nhảy và đối tượng đã chạm đất thì mới tiếp tục nhảy.
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumppingSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpadateAnimationState();

    }

    private void UpadateAnimationState()
    {
        MovementState state;
        //--- Nếu chạy tới thì gọi phương thức running
        if (dirX > 0f)
        {
            state = MovementState.running;
            //--- Khi tiến nhân vật sẽ quay mặt lại
            sprite.flipX = false;
        }
        //--- Nếu chạy lùi thì gọi phương thức running
        else if (dirX < 0f)
        {
            state = MovementState.running;
            //--- Khi lùi nhân vật sẽ quay mặt lại
            sprite.flipX = true;
        }
        //--- Nếu bằng 0 thì gọi phương thức running
        else
        {
            state = MovementState.idle;
        }

        //--- Nếu nhảy lên thì dùng hình động nhảy
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        //--- Nếu nhảy lên thì dùng hình động nhảy xuống
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }    
        anim.SetInteger("state", (int)state);
    }    
    private bool IsGrounded()
    {
        //--- Kiểm tra xem đối tượng có chạm đất hay chưa? Nếu có chạm thì trả về true và ngược lại.
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }    

}
