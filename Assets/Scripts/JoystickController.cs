using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform joystickBackground = null;
    [SerializeField] private RectTransform moveableJoytick = null;

    private Vector2 delta = Vector2.zero;
    private Vector2 startPosition = Vector2.zero;

    private Vector2 direction = Vector2.zero;
    public virtual float Horizontal => direction.x;
    public virtual float Vertical => direction.y;
    public bool HasInput => direction != Vector2.zero;

    private void Start()
    {
        delta = joystickBackground.sizeDelta;
        startPosition = joystickBackground.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joystickBackground.position = eventData.position;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
        moveableJoytick.anchoredPosition = direction;

        joystickBackground.anchoredPosition = startPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position, eventData.pressEventCamera, out Vector2 pos))
        {
            direction = pos / delta * 2;
            direction.x = Mathf.Clamp(direction.x, -1, 1);
            direction.y = Mathf.Clamp(direction.y, -1, 1);

            if (direction.magnitude > 1) direction.Normalize();

            Vector2 finalPosition = direction * delta / 3;
            moveableJoytick.anchoredPosition = finalPosition;
        }
    }
}
