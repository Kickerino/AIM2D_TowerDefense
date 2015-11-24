using UnityEngine;
using System.Collections;

public class healthChange2 : MonoBehaviour
{
    public GameObject Player;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.GetComponent<movement>().PlayerLives);
        if (Player.GetComponent<movement>().PlayerLives == 3)
        {
            spriteRenderer.sprite = sprite2;
        }
        if (Player.GetComponent<movement>().PlayerLives == 2)
        {
            spriteRenderer.sprite = sprite3;
        }
    }
}
