using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonController : MonoBehaviour
{

public GameObject imageObject;

    public void setButtonColor(){
        if(Weapon.isShootingUp){
            imageObject.GetComponent<Image>().color = Color.blue;
        }else{
            imageObject.GetComponent<Image>().color = Color.white;
        }
    }
}
