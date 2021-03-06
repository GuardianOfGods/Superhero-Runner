using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCustom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button.ButtonClickedEvent onClick;
    [SerializeField] private Button.ButtonClickedEvent onPress;

    public bool canClick = true;
    private bool isMoveEnter = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (canClick)
        {
            onPress?.Invoke();
            transform.DOScale(.9f, .01f).SetEase(Ease.OutQuint);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (canClick)
        {
            transform.localScale = Vector3.one;
            if (isMoveEnter)
            {
                onClick.Invoke();
                SoundController.Instance.PlayFX(SoundType.ClickBtn);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMoveEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMoveEnter = false;
    }
}
