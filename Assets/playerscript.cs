using UnityEngine;
using System.Collections;

public class playerscript : MonoBehaviour 
{
	//public float speedmps = 20f;
	
	public float forwardForce = 10f;
	public float sideForce = 10f;
	public float jumpForce = 400f;
	
	float mult;
	float lastAxisHoriz = 0;
	float lastAxisVert = 0;
	int blockedHoriz = 0;
	
	public GameObject mainCamera;
	// Use this for initialization
	void Start () 
	{
		mult = rigidbody.mass;
	}
	/*
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
	*/
	
	// Update is called once per frame
	void Update () 
	{		
		float inpH = Input.GetAxis("Horizontal"), inpV = Input.GetAxis("Vertical");
		
		if (inpH < -0.2)
		{
			transform.rotation = new Quaternion(0,90,0,0);
		}
		if (inpH > 0.2)
		{
			transform.rotation = new Quaternion(0,0,0,0);
		}
		
		
		bool moved = false;
		/*
		if (Mathf.Abs(Input.GetAxis("Horizontal"))>0.2)
		{
			animation.CrossFade("run");
			rigidbody.AddForce(transform.forward * forwardForce * Mathf.Abs(Input.GetAxis("Horizontal")) * mult);			
			moved = true;
		}
		if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2)
		{
			animation.CrossFade("run");
			rigidbody.AddForce(Vector3.left * Input.GetAxis("Vertical") * sideForce * mult);
			moved = true;
		}		
		*/
		
		if (inpH != lastAxisHoriz)
		{			
			constantForce.force += Vector3.forward * forwardForce * (inpH - lastAxisHoriz) * mult;			
		}
		
		if (inpV != lastAxisVert)
		{
			
			constantForce.force += Vector3.left * sideForce * (inpV - lastAxisVert) * mult;
		}
		
		if (Mathf.Abs(inpH) > 0.2 || Mathf.Abs(inpV) > 0.2)
		{
			moved = true;
			animation.CrossFade("run");
		}
		
		if (Input.GetButtonDown("Jump"))
		{
			animation.CrossFade("jump");
			rigidbody.AddForce(Vector3.up * jumpForce * mult);
		}
		
		if (!moved)
			animation.CrossFade("idle");
		
		lastAxisVert = inpV;
		lastAxisHoriz = inpH;
		
		//Debug.Log(constantForce.force.ToString());
		
		Vector3 pos = mainCamera.transform.position;
		mainCamera.transform.position = new Vector3(pos.x, transform.position.y + 20, transform.position.z);
	}
}
