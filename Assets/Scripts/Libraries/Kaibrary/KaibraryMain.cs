using UnityEngine;



namespace Kaibrary
{
	public static class VectorTreatTools
	{
		public static float distance(Transform target, Transform another)
		{
			Vector3 heading = target.position - another.position;
			return heading.magnitude;
		}
	}
}