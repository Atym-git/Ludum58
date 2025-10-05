using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [field:SerializeField]
    public Sprite ItemSprite {  get; private set; }
    
    [field:SerializeField]
    public string ItemNotifText {  get; private set; }
    
    [field:SerializeField]
    public float ItemNotifDuration {  get; private set; }

    public void Construct(Sprite itemSprite, string itemNotifText, float itemNotifDuration)
    {
        ItemSprite = itemSprite;
        ItemNotifText = itemNotifText;
        ItemNotifDuration = itemNotifDuration;
    }

    public void OnMouseDown()
    {
        OnClick();
    }

    private void OnEnable()
    {
        ItemSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnClick()
    {
        Inventory.AddItem(gameObject.GetComponent<Item>());
    }

    public void SelfDestruct() => Destroy(gameObject);


}
