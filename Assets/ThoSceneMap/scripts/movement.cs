using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movement : MonoBehaviour
{

    public float speed = 1.5f;
    public int PlayerLives = 3;
    public Text Lives;
    private SpriteRenderer spriteRenderer;
    Animator anim;

    void Start()
    {

        SetLives("Lives : " + PlayerLives);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
           // anim.SetFloat("Left", Mathf.Min(-h));
            anim.Play("Die spritesheet_");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            //anim.SetFloat("Right", Mathf.Min(h));
            anim.Play("Walk_right_up_");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            //anim.SetFloat("Up", Mathf.Min(v));
            anim.Play("Walk_left_up_");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            //anim.SetFloat("Down", Mathf.Min(-v));
            anim.Play("Walk_right_down_");
        }
        else
        {
        anim.Play("Walk_left_down_");
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            PlayerLives--;
            SetLives("Lives : " + PlayerLives);
            if (PlayerLives == 0)
            {
                Destroy(gameObject);
            }
        }
        
        if (other.gameObject.tag == "Lives")
        {
            Destroy(other.gameObject);
            PlayerLives++;
            SetLives("Lives : " + PlayerLives);
        }
        
        if (other.gameObject.tag == "Tower")
        {
            Destroy(other.gameObject);    
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tower")
        {
            Debug.Log("die tower");
        }
    }
    public void SetLives(string text)
    {
        Lives.text = "Lives : " + PlayerLives;
    }
}
