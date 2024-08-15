using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //--- Tốc độ di chuyển
    [SerializeField] private float speed = 1f;
    // Update is called once per frame
    void Update()
    {
        //--- Tạo phương thức để xoay hình ảnh
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
