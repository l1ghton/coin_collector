using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UIElements;

public abstract class Buttons : MonoBehaviour, IPointerDownHandler , IPointerUpHandler
{
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float ScaleFactor = 0.7f;
    private Vector3 OriginalScale;
    private Tween tween;
    [SerializeField] private Ease UpEase;
    [SerializeField] private Ease DownEase;
    public void OnPointerUp(PointerEventData eventData) 
    {
        if (tween != null && tween.IsActive() && tween.IsPlaying())
        {
            tween.Kill();
        }
        tween = transform.DOScale(OriginalScale, duration).SetEase(UpEase).OnComplete(()=> ClickEvent());
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (tween != null && tween.IsActive() && tween.IsPlaying())
        {
            return;
        }
        tween = transform.DOScale(OriginalScale * ScaleFactor, duration).SetEase(DownEase);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        OriginalScale = rectTransform.localScale;
    }

    protected abstract void ClickEvent();
    // Update is called once per frame
    void Update()
    {
        
    }
}
