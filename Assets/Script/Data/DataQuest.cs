using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class DataQuestParam : CsvDataParam
{
    public int Quest_ID;
    public bool Clear_bool;
}

public class DataQuest : CsvData<DataQuestParam>
{
    
}
