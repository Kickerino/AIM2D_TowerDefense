using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movement : MonoBehaviour
{

    public float speed = 1.5f;
    public int PlayerLives = 6;
    public Text Lives;
    private int collect = 0;
    private SpriteRenderer spriteRenderer;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            anim.Play("Die spritesheet_");
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            anim.Play("Walk_right_up_");
        }
       
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            anim.Play("Walk_left_up_");
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            anim.Play("Walk_right_down_");
        }
        
        else//idle animation
        {
        anim.Play("Walk_left_down_");
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            PlayerLives--;
            
            if (PlayerLives == 0)
            {
                Application.LoadLevel("Defeat");
            }
        }
        
        if (other.gameObject.tag == "Lives")
        {
            Destroy(other.gameObject);
            PlayerLives++;
        }

        //if (other.gameObject.tag == "Tower")
        //{
        //    Destroy(other.gameObject);
        //}

        if (other.gameObject.tag == "Diamond")
        {
            collect++;
        }
        
        if (other.gameObject.tag == "Finish" && collect == 2)
        {
            Application.LoadLevel("victory");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tower")
        {
            Destroy(other.gameObject);
        }
    }
}
