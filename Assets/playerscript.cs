using UnityEngine;
using System.Collections;

public class playerscript : MonoBehaviour 
{
	public float speedmps = 20f;
	public float forwardForce = 100f;
	public float sideForce = 75f;
	public float jumpForce = 4000f;
	
	float mult;
	
	int blockedHoriz = 0;
	
	public GameObject mainCamera;
	// Use this for initialization
	void Start () 
	{
		mult = rigidbody.mass;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "VerticalBarrier")
		{
			++blockedHoriz;
		}
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "VerticalBarrier")
		{
			--blockedHoriz;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	/*
		if (blockedHoriz <= 0 &&  Mathf.Abs(Input.GetAxis("Horizontal"))>0.2 )
		{
			animation.CrossFade("run");
			//transform.position += transform.forward * speedmps * Time.deltaTime * Input.GetAxis("Horizontal");
			rigidbody.AddForce(transform.forward * forwardForce * Input.GetAxis("Horizontal"));
		}*/
		
		if (Input.GetAxis("Horizontal") < -0.2)
		{
			transform.rotation = new Quaternion(0,90,0,0);
		}
		else
			transform.rotation = new Quaternion(0,0,0,0);
		
		bool moved = false;
		if (Mathf.Abs(Input.GetAxis("Horizontal"))>0.2 )
		{
			animation.CrossFade("run");
			//transform.position += transform.forward * speedmps * Time.deltaTime * Input.GetAxis("Horizontal");
			rigidbody.AddForce(transform.forward * forwardForce * Mathf.Abs(Input.GetAxis("Horizontal")) * mult);
			moved = true;
		}
		if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2)
		{
			animation.CrossFade("run");
			rigidbody.AddForce(Vector3.left * Input.GetAxis("Vertical") * sideForce * mult);
			moved = true;
		}		
		
		if (Input.GetButtonDown("Jump"))
		{
			animation.CrossFade("jump");
			rigidbody.AddForce(transform.up * jumpForce * mult);
		}
		
		if (!moved)
			animation.CrossFade("idle");
		
		
		
		Vector3 pos = mainCamera.transform.position;
		mainCamera.transform.position = new Vector3(pos.x, transform.position.y + 20, transform.position.z);
	}
}
