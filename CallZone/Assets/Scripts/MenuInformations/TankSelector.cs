using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TankSelector : MonoBehaviour {


    public AudioController soundController;

    public TankBase[] bases;
    public TankTurret[] turrets;

    public int PlayerNumber;

    private int baseIndex = 0;
    private int turretIndex = 0;

    //public Text baseText;
    //public Text turretText;

    public TextMeshProUGUI _mainCourse;
    public TextMeshProUGUI _appertizer;

    public Button advanceBase, backBase;
    public Button advanceTurret, backTurret;

    public SpriteRenderer spriteRendBase;
    public SpriteRenderer spriteRendTuret;

    void Start ()
    {
        
        TankSettings.tankInfo[PlayerNumber].baseTank = bases[baseIndex];
        spriteRendBase.sprite = bases[baseIndex]._BodySprite;
        
        //baseText.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name;
        _mainCourse.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name;

        TankSettings.tankInfo[PlayerNumber].turret = turrets[turretIndex];
        spriteRendTuret.sprite = turrets[turretIndex]._TowerSprite;

        //turretText.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name;
        _appertizer.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name;
    }
    public void AdvanceBase ()
    {
        baseIndex++;
        VerifyIndex(ref baseIndex);
        TankSettings.tankInfo[PlayerNumber].baseTank = bases[baseIndex];
        spriteRendBase.sprite = bases[baseIndex]._BodySprite;

        //baseText.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name;
        _mainCourse.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name;

        soundController.Playsound(0, 0, false);
    }

    public void BackBase ()
    {
        baseIndex--;
        VerifyIndex(ref baseIndex);
        TankSettings.tankInfo[PlayerNumber].baseTank = bases[baseIndex];
        spriteRendBase.sprite = bases[baseIndex]._BodySprite;

        //baseText.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name;
        _mainCourse.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name;

        soundController.Playsound(0, 0, false);
    }

    public void AdvanceTurret()
    {
        turretIndex++;
        VerifyIndex(ref turretIndex);
        TankSettings.tankInfo[PlayerNumber].turret = turrets[turretIndex];
        spriteRendTuret.sprite = turrets[turretIndex]._TowerSprite;


        //turretText.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name;
        _appertizer.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name;

        soundController.Playsound(0, 0, false);
    }

    public void BackTurret()
    {
        
        turretIndex--;
        VerifyIndex(ref turretIndex);
        TankSettings.tankInfo[PlayerNumber].turret = turrets[turretIndex];
        spriteRendTuret.sprite = turrets[turretIndex]._TowerSprite;


        //turretText.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name;
        _appertizer.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name;

        soundController.Playsound(0, 0, false);
    }

    public void VerifyIndex(ref int index)
    {
        if (index > bases.Length - 1) { index = 0; }
        else if(index < 0)
        {
            index = bases.Length - 1;
        }
    }
}
