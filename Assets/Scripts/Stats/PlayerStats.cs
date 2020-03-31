using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem , Equipment oldItem)
    {
        Debug.Log("in CallBack");
        if(newItem != null)
        {
            Debug.Log("callback Adding" + newItem.name) ;
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if(oldItem != null)
        {
            Debug.Log("callback Removing" + oldItem.name);
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
