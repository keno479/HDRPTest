using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class MasterQuestParam : CsvDataParam
{
    public int Quest_ID;
    public string Quest_Content;
    public string Target_Type;
    public int Target_ID;
    public int Goal;
    public int Reward_Type;
    public int Reward_ID;
}

public class MasterQuest : CsvData<MasterQuestParam>
{

}
