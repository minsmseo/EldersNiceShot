using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var speed = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        var direction = Vector3.Reflect(collision.gameObject.GetComponent<Rigidbody>().velocity.normalized, collision.contacts[0].normal);

        collision.gameObject.GetComponent<Rigidbody>().velocity = direction * Mathf.Max(speed, 5f);
    }
}
