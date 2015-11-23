using UnityEngine;
using System.Collections;

public class noFollow : MonoBehaviour {

    public float speed = 3f;
    public float lifetime = 6.0f;
    private bool Shoot = true;
    void Update()
    {
        if (Shoot == true)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }
    void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
