using UnityEngine;
using UnityEngine.UI;

public class CanvasSettings : MonoBehaviour
{
   [Header("Design")]
   [SerializeField] private CanvasDesignVariant _designVariant;

   [Header("Elements")]
   [SerializeField] private Image _backGroundImage;

   #if UNITY_EDITOR
   private void OnValidate()
   {
      _backGroundImage.color = _designVariant.BackGroundColor;
   }
   #endif

   private void Awake()
   {
      _backGroundImage.color = _designVariant.BackGroundColor;
   }
}
