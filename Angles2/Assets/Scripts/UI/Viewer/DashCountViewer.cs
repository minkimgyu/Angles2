using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCountViewer : BaseViewer
{
    [SerializeField] Image _fillContent;

    public override void UpdateViewer(float ratio) 
    {
        _fillContent.fillAmount = ratio;
    }

    public void FillViewer(float ratio)
    {
        _fillContent.fillAmount = ratio;
    }

    public override void OnOffViewer(bool show)
    {
        gameObject.SetActive(show);
    }
}
