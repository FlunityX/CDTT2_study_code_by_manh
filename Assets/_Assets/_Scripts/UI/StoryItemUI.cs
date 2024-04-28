using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryItemUI : MonoBehaviour
{
    public TextMeshProUGUI storyText;

    private void Start()
    {
        Hide();
    }

    public void UpdateUI()
    {
        storyText.text = PlayerInventory.Instance.storiesItem[0].itemContent.ToString();
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
