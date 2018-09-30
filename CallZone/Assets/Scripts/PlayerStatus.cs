using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {



    [SerializeField]
    private Image _LifeBar;
    private Image _EnergyBar;

    public void SetFillAmountLife (float totalLife)
    {
        _LifeBar.fillAmount = totalLife;
    }

    public void SetFillAmountEnergy (float energy)
    {
        _EnergyBar.fillAmount = energy;
    }
  
}
