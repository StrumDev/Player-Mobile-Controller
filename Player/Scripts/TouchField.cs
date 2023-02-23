// SrtumDev
// YouTube https://www.youtube.com/channel/UCsAcfm0AVVZwLiJ3D451R3g/featured
// Discord https://discord.gg/GtzqG7pgNJ
// GitHub https://github.com/StrumDev

using UnityEngine;
using UnityEngine.EventSystems;

public class TouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 TouchAxis { get; private set; }

    private Vector2 pointer;
    private int pointerId;
    private bool inputTouch;

    private void Update()
    {
        if (inputTouch)
        {   
            if (pointerId >= 0 && pointerId < Input.touches.Length)
            {
                TouchAxis = Input.touches[pointerId].position - pointer;
                pointer = Input.touches[pointerId].position;
                return;
            }

            TouchAxis = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointer;
            pointer = Input.mousePosition;
        }
        else TouchAxis = new Vector2();
    }

    public void OnPointerDown(PointerEventData e)
    {
        inputTouch = true;
        pointer = e.position;
        pointerId = e.pointerId;
    }
    
    public void OnPointerUp(PointerEventData eventData) => inputTouch = false;
}