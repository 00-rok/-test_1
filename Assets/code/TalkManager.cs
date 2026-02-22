using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;//여기있는 녀석이랑 게임메니저에 있는 토크데이터랑 같은녀석인가?
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;



    void Awake()
    {
        talkData = new Dictionary<int, string[]>();     //모든 텍스트를 들고있음
        portraitData = new Dictionary<int, Sprite>();


        GenerateData();
    }
    void GenerateData()
    {
        //talkData.Add(해당하는 ID를 넣어주면 됩니다, new string[] { "원하는 말넣고"}
        talkData.Add(1003, new string[] { "안녕:0", "드디어 날 볼수있구나:1","그런데 무빙워크처럼 움직이는거야?:2"," 다른프레임은 없어?:2" });
        talkData.Add(101, new string[] { "안녕 난 문이야 ","아직 다음칸으로 가는건 불가능해", "아직 구현이 안되었어" });
        talkData.Add(301, new string[] { "책장이다." });
        talkData.Add(3001, new string[] { "드디어 따라가는걸 구현하고 대화도 깔끔하게 잘정리했습니다:0", "대화창 관련해서 동제씨가 잘알고계시면:0", "대화창 관련해서 한번 얘기해봐야할듯 합니다:0" });
        talkData.Add(4001, new string[] { "이렇게 여러명을 붙여놓을수도 있어:1", "제가 해야할게 많아서 그거 다하고나면:0", " 이거 계속 만들게요:0" });


        //대화창 
        portraitData.Add(1003 + 0, portraitArr[0]);
        portraitData.Add(1003 + 1, portraitArr[1]);
        portraitData.Add(1003 + 2, portraitArr[2]);
        portraitData.Add(1003 + 3, portraitArr[3]);

        portraitData.Add(3001 + 0, portraitArr[0]);
        portraitData.Add(3001 + 1, portraitArr[1]);
        portraitData.Add(3001 + 2, portraitArr[2]);
        portraitData.Add(3001 + 3, portraitArr[3]);

        portraitData.Add(4001 + 0, portraitArr[0]);
        portraitData.Add(4001 + 1, portraitArr[1]);
        portraitData.Add(4001 + 2, portraitArr[2]);
        portraitData.Add(4001 + 3, portraitArr[3]);


    }
    // 0,1,2

    public string GetTalk(int id,int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {

            return talkData[id][talkIndex];//이놈이 들고오는듯?
        }


    }

    public Sprite Getportrait(int id,int portraitIndex)
    {
        return portraitData[id+portraitIndex];
    }
    



}
