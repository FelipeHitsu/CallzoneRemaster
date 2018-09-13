using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankInfo : MonoBehaviour {

    public Sprite[] spritesTanksBase;
    public Text tankName;

    private int indexInitial = 0;
    
    private SpriteRenderer spriteRend;

	// Use this for initialization
	void Start ()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        GetSpriteRend(indexInitial);
    }
	
	// Update is called once per frame
	void Update ()
    {

        Debug.Log(indexInitial);

        if (indexInitial > spritesTanksBase.Length)
        {
            indexInitial = 0;
            Debug.Log("fora do range, otário");
        }
        else if (indexInitial < 0)
        {
            indexInitial = spritesTanksBase.Length;
            Debug.Log("fora do range, otário");
        }
    }


    public void GetSpriteRend(int index)
    {
        GetComponent<SpriteRenderer>().sprite = spritesTanksBase[index];
        string tankname = spritesTanksBase[index].name;

        tankName.text = tankname;
        
    }

    //Função que avança o modelo do tanque quando o botão for pressionado
    public void AdvanceButton()
    {
        //
        GetComponent<SpriteRenderer>().sprite = spritesTanksBase[indexInitial += 1];
        string tankname = spritesTanksBase[indexInitial].name;

       

        tankName.text = tankname;
       
    }

    public void BackButton()
    {
        
        GetComponent<SpriteRenderer>().sprite = spritesTanksBase[indexInitial -= 1];
        string tankname = spritesTanksBase[indexInitial].name;

        

        tankName.text = tankname;
        
    }

    
    

    


    

    
}
