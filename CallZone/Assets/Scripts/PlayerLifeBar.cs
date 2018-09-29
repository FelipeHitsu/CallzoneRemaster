using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBar : MonoBehaviour {

    [SerializeField]
    private float _lifeFillAmount;

    [SerializeField]
    private Image _LifeBar;

    public int _playerNumber;

    public int MaxValue;

    public int currentLife;
    

	// Update is called once per frame
	void Update ()
    {
        HandleBar();

        Map(currentLife,0,MaxValue,0,1);

    }
    
    public void HandleBar ()
    {
        if(_lifeFillAmount != _LifeBar.fillAmount)
            _LifeBar.fillAmount = _lifeFillAmount;
    }

    private float Map(float value, float inMin, float inMax, float fillMin, float fillMax)
    {
        return ((value - inMin) * (fillMax - fillMin) / (inMax - inMin) + fillMin);
    }
}
