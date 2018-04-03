using UnityEngine;
using System.Collections;

public class ObjectRayCaster3D : MonoBehaviour
{
	[SerializeField] Transform objectHit;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			castingRay(Input.GetTouch(0));
			
		}
	}

	public void castingRay()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);

		Debug.DrawRay(ray.origin, ray.direction, Color.red, 2f);
		if (Physics.Raycast(ray, out hit))
		{
			objectHit = hit.transform;

			

			// Do something with the object that was hit by the raycast.
		}
	}

	public void castingRay(Touch finger)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(finger.position);

		Debug.DrawRay(ray.origin, ray.direction, Color.red, 2f);
		if (Physics.Raycast(ray, out hit))
		{
			objectHit = hit.transform;



			// Do something with the object that was hit by the raycast.
		}
	}
}
