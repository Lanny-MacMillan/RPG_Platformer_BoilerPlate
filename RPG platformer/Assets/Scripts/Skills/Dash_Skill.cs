using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash_Skill : Skill
{
    [Header("Dash")]
    [SerializeField] private UI_SkillTreeSlot dashUnlockButton;

    public bool dashUnlocked { get; private set; }

    [Header("Clone on Dash")]
    [SerializeField] private UI_SkillTreeSlot cloneOnDashUnlockButton;

    public bool cloneOnDashUnlocked { get; private set; }

    [Header("Clone on Arrival")]
    [SerializeField] private UI_SkillTreeSlot cloneOnArrivalUnlockedButton;

    public bool cloneOnArrivalUnlocked { get; private set; }


    public override void UseSkill()
    {
        base.UseSkill();

      
    }


    protected override void Start()
    {
        base.Start();


        dashUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockDash);
        cloneOnDashUnlockButton.GetComponent<Button>().onClick.AddListener(UnlockCloneDash);
        cloneOnArrivalUnlockedButton.GetComponent<Button>().onClick.AddListener(UnlockCloneOnArrival); 
    }

    // if talent is unlocked in save game file this function will unlock talents
    protected override void CheckUnlock()
    {
        UnlockDash();
        UnlockCloneDash();
        UnlockCloneOnArrival();
    }

    private void UnlockDash()
    {

        if (dashUnlockButton.unlocked)
            dashUnlocked = true;
    }


    private void UnlockCloneDash()
    {
        if (cloneOnDashUnlockButton.unlocked)
            cloneOnDashUnlocked = true;
    }


    private void UnlockCloneOnArrival()
    {
        if (cloneOnArrivalUnlockedButton.unlocked)
            cloneOnArrivalUnlocked = true;
    }

    public void CloneOnDash()
    {
        if (cloneOnDashUnlocked)
            SkillManager.instance.clone.CreateClone(player.transform, Vector3.zero);
    }

    public void CloneOnArrival()
    {
        if (cloneOnArrivalUnlocked)
            SkillManager.instance.clone.CreateClone(player.transform, Vector3.zero);
    }

}
