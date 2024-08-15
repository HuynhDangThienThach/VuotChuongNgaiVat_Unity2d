using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    //--- Khai báo biến cherries đầu tiên =0
    private int cherries = 0;

    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //--- Kiểm tra xem đối tượng có chạm cherry không?
       if(collision.gameObject.CompareTag("Cherry"))
        {
            collectSound.Play();
            //--- Có chạm thì xóa bỏ đối tượng được truyền vào "cherry" 
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
        }
    }
}
