using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG
{
    public class UI_Inventory : MonoBehaviour
    {
        [SerializeField] private Inventory _uiInventory;
        [SerializeField] private GameObject _uiInventoryCanvasControl;
        [SerializeField] private Transform _itemSlotContainer;
        [SerializeField] private Transform _itemSlotTemplate;

        private void Awake()
        {  
            _itemSlotContainer = transform.Find("itemSlotContainer");
            _itemSlotTemplate = _itemSlotContainer.Find("itemSlotTemplate");
            _uiInventoryCanvasControl.SetActive(false);
        }


        public void SetActive(bool state)
        {
            _uiInventoryCanvasControl.SetActive(state);
        }
        public void SetInventory(Inventory inventory)
        {
            _uiInventory = inventory;

            _uiInventory.OnItemListChanged += Inventory_OnItemListChanged;

            RefreshInventoryItems();
        }

        private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
        {
            RefreshInventoryItems();
        }

        public void RefreshInventoryItems()
        {
            foreach(Transform child in _itemSlotContainer)
            {
                if (child == _itemSlotTemplate) continue;
                Destroy(child.gameObject);
            }

            int x = 0;
            int y = 0;
            float itemSlotCellSize = 30f;
            foreach(Item item in _uiInventory.GetItemList())
            {
                RectTransform itemSlotRectTransform = Instantiate(_itemSlotTemplate, _itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                Image image = itemSlotRectTransform.Find("ItemIcon").GetComponent<Image>();
                image.sprite = item.GetSprite();
                TextMeshProUGUI textUI = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();  
                if(item.GetItemAmount() > 1)
                {
                    textUI.SetText(item.GetItemAmount().ToString());
                }
                else
                {
                    textUI.SetText("");
                }
                x++;
                if(x>2)
                {
                    x = 0;
                    y--;
                }
            }
        }
    }
}
