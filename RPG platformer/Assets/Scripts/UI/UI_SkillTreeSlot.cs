using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SkillTreeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private UI ui;

    [SerializeField] private Image skillImage;
    [SerializeField] private string skillName;
    [SerializeField] private int skillPrice;

    [TextArea]
    [SerializeField] private string skillDescription;
    [SerializeField] private Color lockedSkillColor;

    public bool unlocked;

    // will drag and drop what needs to be unlock in the inpector panel. Example on Skill 2 you will need skill 1 unlocked first so drag skill one into "should be unlocked" field
    [SerializeField] private UI_SkillTreeSlot[] shouldBeUnlocked;

    // will drag and drop what needs to be locked in the inpector panel. Example on Skill 4-6 if activated it will lock off the other ability
    [SerializeField] private UI_SkillTreeSlot[] shouldBeLocked;


    private void OnValidate()
    {
        gameObject.name = "SkillTreeSlot_UI - " + skillName;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => UnlockSkillSlot());
    }

    // Start is called before the first frame update
    void Start()
    {
        skillImage = GetComponent<Image>();
        ui = GetComponentInParent<UI>();
        skillImage.color = lockedSkillColor;
    }

    public void UnlockSkillSlot()
    {
        if (!PlayerManager.instance.HaveEnoughCurrency(skillPrice))
            return;


        Debug.Log("Slot Unlocked");

        for(int i =0; i < shouldBeUnlocked.Length; i++)
        {
            if (shouldBeUnlocked[i].unlocked == false)
            {
                Debug.Log("Can not Unlock Skill");
                return;
            }
        }

        for (int i = 0; i < shouldBeLocked.Length; i++)
        {
            if (shouldBeLocked[i].unlocked == true)
            {
                Debug.Log("Not Able to Unlock Skill");
                return;
            }
        }

        unlocked = true;
        skillImage.color = Color.white;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.skillToolTip.ShowTooltip(skillDescription, skillName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ui.skillToolTip.HideTooltip();
    }
}
