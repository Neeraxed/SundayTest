using UnityEngine;
using UnityEngine.UI;

public class ChosenImageSetter : MonoBehaviour
{ 
    [SerializeField] private Image childImage;

    private void Awake()
    {
        if (SingletonObject.ChosenImageToView != null)
            childImage.sprite = SingletonObject.ChosenImageToView;
    }

}
