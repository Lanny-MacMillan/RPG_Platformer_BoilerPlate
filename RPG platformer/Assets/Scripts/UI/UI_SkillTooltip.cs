using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_SkillTooltip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skillDescription;
    [SerializeField] private TextMeshProUGUI skillName;

    public void ShowTooltip(string _skillDescription, string _skillName)
    {
        skillName.text = _skillName;
        skillDescription.text = _skillDescription;
        gameObject.SetActive(true);
    }

    public void HideTooltip() => gameObject.SetActive(false);
}
