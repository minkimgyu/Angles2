using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDieCountViewer : BaseViewer
{
    [SerializeField] TMP_Text _dieCountTxt;

    public override void UpdateViewer(int count)
    {
        _dieCountTxt.text = count.ToString();
    }
}
