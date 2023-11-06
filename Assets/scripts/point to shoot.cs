using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointtoshoot : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public GameObject crossair;
    private Vector3 target;
    public GameObject bulletPrefab;
    public GameObject player_0;

    public float bulletSpeed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {
        

        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crossair.transform.position = new Vector2(target.x, target.y);
        /*
        Vector3 difference = target - player_0.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        

        if (Input.GetMouseButtonDown(0))
        {          
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
           
        }
        void fireBullet(Vector2 direction, float rotationZ)
        {
            GameObject b = Instantiate(bulletPrefab) as GameObject;
            b.transform.position = player_0.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
        }
        */
    }


}
