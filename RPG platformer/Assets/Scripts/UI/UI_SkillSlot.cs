//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class UI_SkillSlot : MonoBehaviour
//{
//    [SerializeField] private string statName;
//    [SerializeField] private StatType statType;
//    [SerializeField] private TextMeshProUGUI statValueText;
//    [SerializeField] private TextMeshProUGUI statNameText;

//    private void OnValidate()
//    {
//        gameObject.name = "Stat - " + statName;


//        if (statName != null)
//            statNameText.text = statName;
//    }

//    private void Start()
//    {
//        UpdateStatValueUI();
//    }

//    public void UpdateStatValueUI()
//    {
//        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

//        if(playerStats != null)
//        {
//            statValueText.text = playerStats.GetStat(statType).GetValue().ToString();
//        }
//    }
//}
