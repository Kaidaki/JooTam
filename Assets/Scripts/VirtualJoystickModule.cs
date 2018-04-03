using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystickModule : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	[SerializeField] Image bgImg;
	[SerializeField] Image joystickImg;
	Vector3 inputVector;

	// Use this for initialization
	void Start()
	{
		bgImg = GetComponent<Image>();
		joystickImg = transform.GetChild(0).GetComponent<Image>();
	}

	public void OnDrag(PointerEventData ped)
	{
		Vector2 pos;

		if (RectTransformUtility.ScreenPointToLocalPointInRectangle
			(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = inputVector = new Vector3(pos.x * 2f, 0f, pos.y * 2f);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 2), inputVector.z * (bgImg.rectTransform.sizeDelta.y / 2));
		}
	}

	public void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
	}


	public float horizontal()
	{
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis("Horizontal");
	}

	public float vertical()
	{
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis("Vertical");
	}
}
