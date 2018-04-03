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

	public static class ExpandedMath
	{
		/// <summary>
		///		Calculate the least[lowest] common multiple(LCM) between two integer
		/// </summary>
		/// <param name="num1">first number</param>
		/// <param name="num2">second numbery</param>
		/// <returns>LCM number</returns>
		public static int LCM(int num1, int num2)
		{
			int x, y = 0;
			
			x = num1;
			y = num2;

			while(num1 != num2)
			{
				if(num1 > num2)
					num1 = num1 - num2;

				else
					num2 = num2 - num1;
			}
			return (x * y) / num1;
		}
	}
}