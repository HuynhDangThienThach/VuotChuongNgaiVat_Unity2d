using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSound;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //--- Kiểm tra xem đối tượng có nhảy vào Trap không
        if(collision.gameObject.CompareTag("Trap"))
        {
            deathSound.Play();
            Die();
        }    
    }

    private void Die()
    {
        //--- Chuyển về static để nhân vật không được di chuyển
        rb.bodyType = RigidbodyType2D.Static;
        //--- Hình ảnh đối tượng Die 
        //--- death trong animation
        anim.SetTrigger("death");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
}
