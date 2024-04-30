using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class StoryItemUI : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public TextMeshProUGUI storyHeaderText;
    public Image backGround;
    private int index=0;
    [SerializeField] private Button closeBtn;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button preBtn;
    private void Start()
    {
        Hide();
        nextBtn.onClick.AddListener(() =>
        {
            index++;
            if(index > 3) index = 0;
            UpdateUI(); 
        });
        preBtn.onClick.AddListener(() => { 
            index--;
            if(index < 0) index= 3;
            UpdateUI();
        });
        closeBtn.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    public void UpdateUI()
    {
        if (PlayerInventory.Instance.storiesItem[index] != null)
        {
            storyHeaderText.text = (index + 1).ToString() + " " + PlayerInventory.Instance.storiesItem[index].itemHeaderContent;
            storyText.text = PlayerInventory.Instance.storiesItem[index].itemContent;
        }
        else
        {
            storyHeaderText.text = (index+1).ToString() + " " + GameConstant.STORY_ITEM_UNDEFINE_CONTENT;
            storyText.text = GameConstant.STORY_ITEM_UNDEFINE_CONTENT;
        }
    }

    public void Show()
    {
        UpdateUI();
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
