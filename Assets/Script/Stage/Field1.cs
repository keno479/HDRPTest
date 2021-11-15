using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field1 : MonoBehaviour
{
    public Field1()
    {
        MasterStageParam master = DataManager.Instance.masterstage.list.Find(p => p.Stage_Name == "Field1");
        DataStageParam data = DataManager.Instance.datastage.list.Find(p => p.Stage_ID == master.Stage_ID);
        data.is_Open = true;
        DataManager.Instance.datastage.Save();
    }
}