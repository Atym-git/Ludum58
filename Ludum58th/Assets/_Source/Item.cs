using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    [field:SerializeField]
    public Sprite ItemSprite {  get; private set; }
    
    [field:SerializeField]
    public string ItemNotifText {  get; private set; }

    private void OnMouseDown()
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
