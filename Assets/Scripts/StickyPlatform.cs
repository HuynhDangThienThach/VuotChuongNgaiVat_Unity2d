using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    /*  Việc sử dụng OnTriggerEnter2D là để đối tượng không bị kéo nhau khi
        va chạm thay vì sử dụng OnCollisionEnter2D
    */
    //--- Xảy ra va chạm giữa Player và Way 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    //--- Cho phép đối tượng player có thể di chuyển khỏi way 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
