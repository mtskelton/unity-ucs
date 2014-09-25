using UnityEngine;
using System.Collections;

/**
 * The Universal Coordinate System provides a simple class to convert screen independent co-ordinates from -1.0 to 1.0 into screen space,
 * taking into account aspect ratio.
 * It's a bit raw in it's current state, so improvements are welcome.
 */
public class UCS : MonoBehaviour {
	static float aspectX = 0.0f;
	static float aspectY = 0.0f;
	static float halfX = Screen.width / 2.0f;
	static float halfY = Screen.height / 2.0f;
	static float padX = 0.0f;
	static float padY = 0.0f;


	public static Rect ConvertRect(Rect rect) {
		rect.x = ConvertX (rect.x);
		rect.y = ConvertY (rect.y);
		rect.width = ConvertW (rect.width);
		rect.height = ConvertH (rect.height);
		return rect;
	}

	public static float ConvertX(float x) {
		return ConvertW (x+GetPadX()) + (halfX / GetAspectX ());
	}

	public static float ConvertY(float y) {
		return ConvertH (y+GetPadY()) + (halfY / GetAspectY ());
	}

	/**
	 * Return additional screen space on X axis
	 */
	public static float GetPadX() {
		CheckAspect ();
		return padX;
	}

	public static float GetPadY() {
		CheckAspect ();
		return padY;
	}

	public static float ConvertW(float x) {
		return (x * (halfX / GetAspectX()));
	}
	
	public static float ConvertH(float y) {
		return (y * (halfY / GetAspectY()));
	}

	private static float GetAspectY() {
		CheckAspect ();
		return aspectY;
	}
	private static float GetAspectX() {
		CheckAspect ();
		return aspectX;
	}

	private static void CheckAspect() {
		if (aspectX != 0.0f)
			return;
		aspectX = 1.0f; aspectY = 1.0f;
		if(Screen.width > Screen.height) {
			aspectX = (Screen.width * 1.0f) / (Screen.height * 1.0f);
		} else {
			aspectY = (Screen.height * 1.0f) / (Screen.width * 1.0f);
		}
		padX = aspectX - 1.0f;
		padY = aspectY - 1.0f;
	}

	/**
	 * Returns the full available width of the screen in universal co-ordinates.
	 */
	public static float GetWidth() {
		CheckAspect ();
		return (2.0f + (padX * 2)) / 2;
	}

	/**
	 * Returns the full available width of the screen in universal co-ordinates.
	 */
	public static float GetHeight() {
		CheckAspect ();
		return (2.0f + (padY * 2)) / 2;
	}

	public static int FontSize(int size) {
		return (int)((size * Screen.height) / 480.0f);
	}
}
