using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollViewItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image childImage;
   // [SerializeField] private SceneLoader sceneLoader;
    
    public void ChangeImage(Sprite sprite )
    {
        childImage.sprite = sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       // SceneLoader.Reload("View");
        SceneLoader.DefaultLoad("View");
        SingletonObject.ChosenImageToView = this.childImage.sprite;
    }
}

public static class SingletonObject
{
    public static Sprite ChosenImageToView;
}