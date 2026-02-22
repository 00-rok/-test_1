using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI talk;
    public GameObject scanObject;
    public GameObject talkPanel;
    public GameObject inventory;
    public GameObject Menu;
    public TalkManager talkManager;
    public Image portraitImg;
    public bool isTalk;//대화중엔 아무것도 안열리게
    public bool isInventory;//인벤토리를 연상태에선 움직임 불가 하지만 esc로 닫힐수 있어야함
    public bool isMenu;// esc중에는 esc만
    public int talkindex;


    public void Awake()
    {
        isTalk = false;
        talkPanel.SetActive(isTalk);
        isInventory = false;
        inventory.SetActive(isInventory);
        isMenu = false;
        Menu.SetActive(isMenu);

}

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        Object_Data objData = scanObject.GetComponent<Object_Data>();
        Debug.Log("여기까진 ok1" + objData.isNPC);
        Talk(objData.ID , objData.isNPC);//대화창이 뜨기전에 먼저 고유 ID와 NPC여부를 확인하고 생성까지 하나 여기서?

        Debug.Log("여기까진 ok2");
        talkPanel.SetActive(isTalk);//->이놈이 일단 대화창을 생성하는것일꺼임


    }
    public void Call_inventory()
    {
        isInventory = true;
        inventory.SetActive(isInventory);
    }
    public void Off_Call_inventory()
    {
        isInventory = false;
        inventory.SetActive(isInventory);
    }
    public void Call_Menu()
    {
        isMenu = true;
        Menu.SetActive(isMenu);
    }
    public void Off_Call_Menu()
    {
        isMenu = false;
        Menu.SetActive(isMenu);
    }
    void Talk(int id,bool isNPC)
    {                                               //이놈은 딱 하나의 텍스트를 들고있음
        string talkData = talkManager.GetTalk(id, talkindex);//임시로 토크데이터를 만든녀석임 임시로 만들어서 겟토크를 실행해 토크메니저에이는 토크 데이터를 들고오는것?
        if (talkData == null)
        {
            isTalk = false;
            talkindex = 0;
            return;
        }


        if(isNPC)
        {

            talk.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.Getportrait(id, int.Parse(talkData.Split(':')[1])); 
            portraitImg.color = new Color(1, 1, 1, 1);//불투명

        }
        else
        {
            talk.text= talkData;
            portraitImg.color = new Color(1, 1, 1, 0);//투명
        }
        isTalk=true;
        talkindex++;



    }


}
