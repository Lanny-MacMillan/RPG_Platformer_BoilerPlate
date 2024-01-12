using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parry_Skill : Skill
{
    [Header("Parry")]
    [SerializeField] private UI_SkillTreeSlot parryUnlockButton;
    public bool parryUnlocked { get; private set; }


    [Header("Parry Restore")]
    [SerializeField] private UI_SkillTreeSlot parryRestoreUnlockButton;
    [Range (0f,1f)]
    [SerializeField] private float restoreHealthPercentage;
    public bool parryRestoreUnlocked { get; private set; }

    [Header("Parry Mirage")]
    [SerializeField] private UI_SkillTreeSlot parryMirageUnlockButton;
    public bool parryMirageUnlocked { get; private set; }





    public override void UseSkill()
    {
        base.UseSkill();

        if (parryRestoreUnlocked)
        {
            int restoreAmount = Mathf.RoundToInt(player.stats.GetMaxHealthValue() * restoreHealthPercentage);
            player.stats.IncreaseHealthBy(restoreAmount);
        }
    }

    protected override void Start()
    {
        base.Start();

        parryUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParry);
        parryRestoreUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParryRestore);
        parryMirageUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockParryMirage);
    }

    // if talent is unlocked in save game file this function will unlock talents
    protected override void CheckUnlock()
    {
        UnlockParry();
        UnlockParryRestore();
        UnlockParryMirage();
    }

    private void UnlockParry()
    {
        if (parryUnlockButton.unlocked)
            parryUnlocked = true;
    }

    private void UnlockParryRestore()
    {
        if (parryRestoreUnlockButton.unlocked)
            parryRestoreUnlocked = true;
    }

    private void UnlockParryMirage()
    {
        if (parryMirageUnlockButton.unlocked)
            parryMirageUnlocked = true;
    }

    public void MakeMirageOnParry(Transform _respawnTransform)
    {
        if (parryMirageUnlocked)
            SkillManager.instance.clone.CreateCloneWihDelay(_respawnTransform);
    }
}
