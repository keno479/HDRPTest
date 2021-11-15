using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class DataStageParam : CsvDataParam
{
    public int Stage_ID;
    public bool is_Open;
}

public class DataStage : CsvData<DataStageParam>
{

}