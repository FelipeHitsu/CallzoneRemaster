using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankSelector : MonoBehaviour {

    public Sprite[] Base;
    public Sprite[] Turret;

    public int PlayerNumber;

    private int baseIndex = 0;

    public Text baseText;
    public Text turretText;

    public Button advanceBase, backBase;
    public Button advanceTurret, backTurret;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AdvanceBase ()
    {
        TankSettings.tankInfo[PlayerNumber]._BodySprite = Base[baseIndex ++];
        string name = TankSettings.tankInfo[PlayerNumber]._BodySprite.name;

        baseText.text = name;
    }

    public void BackBase ()
    {
        TankSettings.tankInfo[PlayerNumber]._BodySprite = Base[baseIndex--];
        string name = TankSettings.tankInfo[PlayerNumber]._BodySprite.name;

        baseText.text = name;
    }

    //public void AdvanceTurret ()
    //{
    //    TankSettings.tankInfo[PlayerNumber]._bullet = Turret[baseIndex++];
    //}

    //public void BackTurret ()
    //{

    //}
}
