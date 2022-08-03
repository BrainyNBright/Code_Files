using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyc : MonoBehaviour
{
    private Rigidbody rb;
    private int speed=5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed);
    }
    void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("l"))
		{
			speed=5;
		}
		if (other.gameObject.CompareTag ("r"))
		{
			speed=-5;
		}
	}
}
