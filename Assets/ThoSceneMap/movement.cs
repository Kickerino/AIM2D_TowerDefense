using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{

    public float speed = 1.5f;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite1;
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
            ChangeSpriteUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            ChangeSpriteDown();
        }
    }
    void ChangeSpriteUp()
    {
        if (spriteRenderer.sprite != sprite2)
        {
            spriteRenderer.sprite = sprite2;
        }
    }

    void ChangeSpriteLeft()
    {
        if (spriteRenderer.sprite != sprite1)
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    void ChangeSpriteDown()
    {
        if (spriteRenderer.sprite != sprite4)
        {
            spriteRenderer.sprite = sprite4;
        }
    }
    
    void ChangeSpriteRight()
    {
        if (spriteRenderer.sprite != sprite3)
        {
            spriteRenderer.sprite = sprite3;
        }
    }
}
