using UnityEngine;

/// <summary>
/// Lớp hỗ trợ tự động điều chỉnh RectTransform để phù hợp với Safe Area trên các thiết bị di động.
/// 
/// Safe Area là vùng màn hình an toàn, không bị che khuất bởi notch, dynamic island, 
/// thanh trạng thái, thanh điều hướng... trên iPhone, Android cao cấp.
/// 
/// Script này nên được gắn vào một UI Panel/Canvas con có anchor bao phủ toàn màn hình.
/// </summary>
[RequireComponent (typeof(RectTransform))]
public class SafeAreaPanel : MonoBehaviour
{
    private void Awake()
    {
        ApplySafeArea();
    }

    private void ApplySafeArea()
    {
        Rect safe = Screen.safeArea;

        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector2 anchorMin = safe.position;
        Vector2 anchorMax = safe.position + safe.size;

        anchorMin.x = anchorMin.x / Screen.width;
        anchorMin.y = anchorMin.y / Screen.height;
        anchorMax.x = anchorMax.x / Screen.width;
        anchorMax.y = anchorMax.y / Screen.height;

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;

        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }
}
