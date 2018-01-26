using UnityEngine;



namespace Kaibrary
{
	public static class VectorTreatTools
	{
		#region Diagonal 2D Vector Properties

		public static Vector2 NE_Vector
		{
			get { return Vector2.up + Vector2.right; }
		}
		public static Vector2 NW_Vector
		{
			get { return Vector2.up + Vector2.left; }
		}
		public static Vector2 SE_Vector
		{
			get { return Vector2.down + Vector2.right; }
		}
		public static Vector2 SW_Vector
		{
			get { return Vector2.down + Vector2.left; }
		}
		#endregion


		public static float distance(Transform target, Transform another)
		{
			Vector3 heading = target.position - another.position;
			return heading.magnitude;
		}		
	}
}