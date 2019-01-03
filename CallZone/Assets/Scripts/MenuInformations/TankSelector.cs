using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TankSelector : MonoBehaviour {

    //Controlador de som 
    public AudioController soundController;

    //As bases com seus atributos
    public TankBase[] bases;
    //As torres com seus atributos
    public TankTurret[] turrets;
    //Os pw's com seus atributos de dano
    public PowerUp pws;

    //Numero do jogador
    public int PlayerNumber;
    
    //Index inicial de base e torre
    private int baseIndex = 0;
    private int turretIndex = 0;

    //Referencias aos textos pra seleção de comida e sobremesa
    public TextMeshProUGUI _mainCourse;
    public TextMeshProUGUI _appertizer;

    //Botões para avançar/voltar bases e torres
    public Button advanceBase, backBase;
    public Button advanceTurret, backTurret;

    //Sprites das bases e das torres
    public SpriteRenderer spriteRendBase;
    public SpriteRenderer spriteRendTuret;

    void Start ()
    {
        
        TankSettings.tankInfo[PlayerNumber].baseTank = bases[baseIndex];
        spriteRendBase.sprite = bases[baseIndex]._BodySprite;
        
        
        _mainCourse.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name;

        TankSettings.tankInfo[PlayerNumber].turret = turrets[turretIndex];
        spriteRendTuret.sprite = turrets[turretIndex]._TowerSprite;

       
        _appertizer.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name;
    }
    public void AdvanceBase ()
    {
        baseIndex++;
        VerifyIndex(ref baseIndex);
        TankSettings.tankInfo[PlayerNumber].baseTank = bases[baseIndex];
        spriteRendBase.sprite = bases[baseIndex]._BodySprite;

       
        _mainCourse.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name;

        soundController.Playsound(0, 0, false);
    }

    public void BackBase ()
    {
        baseIndex--;
        VerifyIndex(ref baseIndex);
        TankSettings.tankInfo[PlayerNumber].baseTank = bases[baseIndex];
        spriteRendBase.sprite = bases[baseIndex]._BodySprite;

        
        _mainCourse.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name;

        soundController.Playsound(0, 0, false);
    }

    public void AdvanceTurret()
    {
        turretIndex++;
        VerifyIndex(ref turretIndex);
        TankSettings.tankInfo[PlayerNumber].turret = turrets[turretIndex];
        spriteRendTuret.sprite = turrets[turretIndex]._TowerSprite;


        _appertizer.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name;

        soundController.Playsound(0, 0, false);
    }

    public void BackTurret()
    {
        
        turretIndex--;
        VerifyIndex(ref turretIndex);
        TankSettings.tankInfo[PlayerNumber].turret = turrets[turretIndex];
        spriteRendTuret.sprite = turrets[turretIndex]._TowerSprite;


       
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
