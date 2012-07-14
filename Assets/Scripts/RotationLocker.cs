using UnityEngine;
using System.Collections;

public class RotationLocker : MonoBehaviour 
{
	public float restriction = 10f;
	// Ограничение на вращение вокруг оси X
	// Update is called once per frame
	void Update () 
	{
		Vector3 vec = transform.rotation.eulerAngles;
		float x = vec.x;
		
		x = Mathf.Clamp(x, -restriction, restriction);
		
		transform.rotation = Quaternion.Euler(new Vector3(x, vec.y, vec.z));
	}
}
