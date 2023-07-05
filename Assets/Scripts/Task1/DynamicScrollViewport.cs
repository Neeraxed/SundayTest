using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicScrollViewport : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int amountOfImages;

    private List<Image> loadedSprites;

    private string url;
    private Sprite current;
    private void Start()
    {
        SetImage();
    }
    
    private void SetImage()
    {
        for (int i = 0; i < amountOfImages; i++)
        {
            StartCoroutine(SetImages(i));
        }
    }

    private IEnumerator SetImages(int i)
    {
        url = $"http://data.ikppbb.com/test-task-unity-data/pics/{i + 1}.jpg";
        var img = new WWW(url);
        yield return img;
        
        current = Sprite.Create(img.texture, new Rect(0, 0, 1000, 1000), Vector2.zero);

        GameObject newItem = Instantiate(prefab, spawnPoint);


        if (newItem.TryGetComponent<ScrollViewItem>(out ScrollViewItem item))
        {
            item.ChangeImage(current);
        }
    }

    // private IEnumerator GetImages(int amount)
    // {
    //     for (int i = 0; i <amount; i++)
    //     {
    //         url = $"http://data.ikppbb.com/test-task-unity-data/pics/{i + 1}.jpg";
    //         var img = new WWW(url);
    //         loadedSprites
    //     }
    // }
}
