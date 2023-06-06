using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject hammer_head;
    public GameObject hammer_stick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector3 force = this.GetComponent<Rigidbody>().velocity;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(3, 0, 0);
            Debug.Log(force);
            Debug.Log("push!");
        }
    } */
}
