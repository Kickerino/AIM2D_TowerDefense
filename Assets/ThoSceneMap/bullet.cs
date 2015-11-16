using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{

    Transform target;
    public float speed = 3f;
    public float lifetime = 6.0f;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90,0), Space.Self);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0,0));
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