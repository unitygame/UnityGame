using UnityEngine;
using System.Collections;

public class ExtraGravity : MonoBehaviour {
	
	public float multyplier = 50f;
	// Use this for initialization
	void Start () 
	{
		Debug.Log(gameObject.name);
		gameObject.AddComponent("ConstantForce");
		constantForce.force = Vector3.down * multyplier * rigidbody.mass;
	}
}
