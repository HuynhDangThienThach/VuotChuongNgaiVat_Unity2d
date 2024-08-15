using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    //--- Tạo 2 điểm đầu và cuối của Way
    [SerializeField] private GameObject[] waypoints;
    //--- Theo dõi chỉ mục của waypoint đang di chuyển
    private int currentWaypointIndex = 0;

    //--- Tốc độ di chuyển của way
    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    private void Update()
    {   //--- Nếu way point di chuyển đến điểm đầu thì sẽ tự quay lại điểm thứ kết thúc và lặp lại
        //---                ---------------------Vị trí hiện waypoint hiện tại-------------------- 
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }    
        }
        transform.position = Vector2.MoveTowards
        (transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
