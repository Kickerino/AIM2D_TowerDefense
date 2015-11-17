using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movement : MonoBehaviour
{

    public float speed = 1.5f;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public int PlayerLives = 3;
    public Text Lives;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite1;
        SetLives("Lives : " + PlayerLives);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            ChangeSpriteLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            ChangeSpriteRight();
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            
        }

    }


    void ChangeSpriteLeft()
    {
        if (spriteRenderer.sprite != sprite1)
        {
            spriteRenderer.sprite = sprite1;
        }
    }



    void ChangeSpriteRight()
    {
        if (spriteRenderer.sprite != sprite3)
        {
            spriteRenderer.sprite = sprite3;
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
    }
    public void SetLives(string text)
    {
        Lives.text = "Lives : " + PlayerLives;
    }
}
