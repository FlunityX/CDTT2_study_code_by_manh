using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectBarUI : ObjectPool
{
    public StatusIconUI[] StatusIcons;

    public override void Start()
    {
        amountToSpawn = 10;
        base.Start();
        SpawnSlot();
        StatusIcons = holder.GetComponentsInChildren<StatusIconUI>();
        SetIndex();
        Player.Instance._statusHolder.onStatusChange += PlayerStatus_onStatusChange;
    }

    private void PlayerStatus_onStatusChange(object sender, System.EventArgs e)
    {
        SpawnSlot();
    }

    private void SetIndex()
    {
        for (int i = 0; i < StatusIcons.Length; i++)
        {
            StatusIcons[i].index = i;
        }
    }

    public void SpawnSlot()
    {
        foreach(Transform child in holder.transform)
        {
            child.gameObject.SetActive(false);
        }
        for (int i = 0; i < Player.Instance._statusHolder.statusEffects.Count; i++)
        {
            GameObject slot = GetObject();
            if(slot  != null)
            {
                slot.SetActive(true);
            }
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
