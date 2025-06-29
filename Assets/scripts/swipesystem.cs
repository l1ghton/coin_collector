using Unity.VisualScripting;
using UnityEngine;

public enum SwipeDirections
{
    None, Left, Right, Top, Bottom
}

public class swipesystem : MonoBehaviour
{
    private float height;
    private float width;
    private float treshold = 0.005f;
    public SwipeDirections swipeDirections { get; private set; }
    public delegate void LeftEventHandler();
    public event LeftEventHandler LeftEvent;
    public delegate void RightEventHandler();
    public event RightEventHandler RightEvent;
    public delegate void TopEventHandler();
    public event TopEventHandler TopEvent;
    public delegate void BottomEventHandler();
    public event BottomEventHandler BottomEvent;
    void OnSwipe() 
    {
        if (swipeDirections == SwipeDirections.Left)
        {
            LeftEvent?.Invoke();
        }
        if (swipeDirections == SwipeDirections.Right)
        {
            RightEvent?.Invoke();
        }
        if (swipeDirections == SwipeDirections.Top)
        {
            TopEvent?.Invoke();
        }
        if (swipeDirections == SwipeDirections.Bottom)
        {
            BottomEvent?.Invoke();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Awake()
    {
        height = Screen.height;
        width = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        swipeDirections = GetSwipeDirection();
        OnSwipe();
    }

    SwipeDirections GetSwipeDirection()
    {
        if (Input.touchCount == 1)
        {
            var touch = Input.GetTouch(0);

            if (touch.deltaPosition.normalized.sqrMagnitude < treshold)
            {
                return SwipeDirections.None;
            }

            float RightDot = Vector2.Dot(Vector2.right, touch.deltaPosition.normalized);
            float DownDot = Vector2.Dot(Vector2.down, touch.deltaPosition.normalized);
            float LeftDot = Vector2.Dot(Vector2.left, touch.deltaPosition.normalized);
            float UpDot = Vector2.Dot(Vector2.up, touch.deltaPosition.normalized);

            float bufer = -1f;
            SwipeDirections sd = SwipeDirections.None;

            if (RightDot > bufer)
            {
                bufer = RightDot;
                sd = SwipeDirections.Right;
            }
            if (DownDot > bufer)
            {
                bufer = DownDot;
                sd = SwipeDirections.Bottom;
            }
            if (LeftDot > bufer)
            {
                bufer = LeftDot;
                sd = SwipeDirections.Left;
            }
            if (UpDot > bufer)
            {
                bufer = UpDot;
                sd = SwipeDirections.Top;
            }
            return sd;
        }
        return SwipeDirections.None;
    }
}