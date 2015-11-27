using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movement : MonoBehaviour
{

    public float speed = 1.5f;
    public int PlayerLives = 6;
    private int collect = 0;
    private SpriteRenderer spriteRenderer;
    public AudioClip attack;
    public AudioClip damage;
    public AudioClip idle;
    public AudioClip pickup;
    public AudioClip end;
    public AudioClip die;
    AudioSource audios;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        audios = GetComponent<AudioSource>();
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

        else if (Input.GetKey(KeyCode.Space))
        {

            StartCoroutine(DoAnimation());
        }
        
        else//idle animation
        {
            if (!audios.isPlaying)
            {
        audios.PlayOneShot(idle, 0.7F);
            }
           
        anim.Play("idle");
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet")
        {

            PlayerLives--;
            audios.PlayOneShot(damage, 0.7f);
            
        }
        if (PlayerLives == 0)
            {
                audios.PlayOneShot(die, 0.7f);
                Application.LoadLevel("defeat");
            }
        
        if (other.gameObject.tag == "Lives")
        {
            Destroy(other.gameObject);
            audios.PlayOneShot(pickup, 0.7F);
            PlayerLives++;
        }

        if (other.gameObject.tag == "Diamond")
        {
            collect++;
            audios.PlayOneShot(pickup, 0.7F);
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
            StartCoroutine(DoAnimation());
            audios.PlayOneShot(attack, 0.7F);
            Destroy(other.gameObject);
        }
    }
    IEnumerator DoAnimation()
    {
        anim.Play("attackleft");
        yield return new WaitForSeconds(2f);
    }
}
