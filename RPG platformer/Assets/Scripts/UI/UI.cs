using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField] public GameObject characterUI;
    [SerializeField] public GameObject skillTreeUI;
    [SerializeField] public GameObject craftingUI;
    [SerializeField] public GameObject optionsUI;

    public UI_SkillTooltip skillToolTip;
    public UI_ItemTooltip itemToolTip;
    public UI_StatTooltip statToolTip;
    public UI_CraftWindow craftWindow;


    void Start()
    {
        SwitchTo(null);

        itemToolTip.gameObject.SetActive(false);
        statToolTip.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            SwitchWithKeyTo(characterUI);

        if (Input.GetKeyDown(KeyCode.B))
            SwitchWithKeyTo(craftingUI);

        if (Input.GetKeyDown(KeyCode.K))
            SwitchWithKeyTo(skillTreeUI);

        if (Input.GetKeyDown(KeyCode.O))
            SwitchWithKeyTo(optionsUI);

    }

    public void SwitchTo(GameObject _menu)
    {
        // cycles through all children of the UI, find all the elements, switch them off
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // switch on the one we need
        if (_menu != null)
            _menu.SetActive(true);
    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if( _menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            return;
        }

        SwitchTo(_menu);
    }
}
