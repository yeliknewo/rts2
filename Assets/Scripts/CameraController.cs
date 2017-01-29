using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
	[SerializeField]
	float zoomSpeed = 5f;
	[SerializeField]
	float minSize = 5f;
	[SerializeField]
	float maxSize = 20f;

	void Update()
	{
		Cursor.lockState = CursorLockMode.Confined;

		if (GetPlayer() == null)
		{
			return;
		}

		Vector2 mousePos = Input.mousePosition;
		mousePos.x = Mathf.Clamp(mousePos.x, 0, Screen.width);
		mousePos.y = Mathf.Clamp(mousePos.y, 0, Screen.height);
		Vector3 mouseInWorld = GetCamera().ScreenToWorldPoint(mousePos);
		Vector3 playerPos = GetPlayer().transform.position;
		transform.position = new Vector3((mouseInWorld.x + playerPos.x) / 2f, transform.position.y, (mouseInWorld.z + playerPos.z) / 2f);
		GetCamera().orthographicSize = Mathf.Clamp(GetCamera().orthographicSize - Input.GetAxis(InputManager.AXIS_MOUSE_SCROLL_WHEEL) * zoomSpeed, minSize, maxSize);
	}

	Camera GetCamera()
	{
		return GetComponent<Camera>();
	}

	PlayerController GetPlayer()
	{
		return FindObjectOfType<PlayerController>();
	}
}
