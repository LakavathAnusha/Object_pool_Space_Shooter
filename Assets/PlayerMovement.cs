using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Slider healthBar;
    public int playerSpeed;
    int playerHealth = 10;
    int maxHealth = 10;
    // public GameObject bulletPrefab;
    public Vector3 offSet;
    public bool isGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
            float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
            transform.Translate(inputY * playerSpeed * Time.deltaTime,inputX * playerSpeed * Time.deltaTime, 0f);
        //Clamp player position within gameWindow
        healthBar.value = (float)playerHealth / 10;
        if (Input.GetKeyDown(KeyCode.Space))
            {

                GameObject tempBullet = PoolScript.instance.GetObjectsFromPool("Bullet");
            if (tempBullet != null)
            {
                tempBullet.transform.position = this.transform.position + offSet;
                // transform.Translate(0f, 0f, 1f);
                tempBullet.SetActive(true);
            }
                //Instantiate(bulletPrefab, transform.position + offSet, Quaternion.identity);
            }
        
       /* if (playerHealth == 0)
        {
            Destroy(gameObject);
            isGameOver = true;
            print("GameOver");

        }*/
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            playerHealth--;
            collision.gameObject.SetActive(false);
            print("player Health Dec:" + playerHealth);

        }
        if (collision.gameObject.tag == "Health" && playerHealth < maxHealth)
        {
            playerHealth = Mathf.Clamp(playerHealth + 1, 0, maxHealth);
            collision.gameObject.SetActive(false);
            print("player Health inc:" + playerHealth);
        }

    }
}