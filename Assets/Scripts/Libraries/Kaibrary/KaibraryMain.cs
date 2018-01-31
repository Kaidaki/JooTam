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

		/// <summary>
		///		Calculate a distance between two 2D Vectors
		/// </summary>
		/// <param name="target">target 2D Vector</param>
		/// <param name="other">other 2D Vector</param>
		/// <returns>the distance between two 2D Vectors</returns>
		public static float distance(Transform target, Transform other)
		{
			Vector3 heading = target.position - other.position;
			return heading.magnitude;
		}	
	}
}