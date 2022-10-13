using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 
public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2d;

    public GameObject gamewonpanel;
    public GameObject GameLostPanel;
    public float speed;

    private bool isGameOver = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true)
        {
            return;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidbody2d.velocity = new Vector2(speed, 0f);

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigidbody2d.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigidbody2d.velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Level complete !!!");
            gamewonpanel.SetActive(true);
            isGameOver = true;
        }
        else if (other.tag == "Enemy")
        {
            Debug.Log("Level LOst !!!");
            GameLostPanel.SetActive(true);
            isGameOver = true;
        }
        
  
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("buttonclicked");
    }

}
