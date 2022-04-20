using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement;
        movement = Input.GetAxis("Horizontal") * speed;
        transform.Translate(0,-movement*Time.deltaTime, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + offset, Quaternion.Euler(0,0,90));
        }
    }
}
