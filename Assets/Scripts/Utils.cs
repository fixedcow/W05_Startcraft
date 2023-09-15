using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	public static Vector3 MousePosition
	{
		get
		{
			Vector3 result = GetMainCamera().ScreenToWorldPoint(Input.mousePosition);
			result.z = 0;
			return result;
		}
	}

	private static Camera main;

	public static Camera GetMainCamera()
	{
		main ??= Camera.main;
		return main;
	}
}
