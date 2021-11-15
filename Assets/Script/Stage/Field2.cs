using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field2 : MonoBehaviour
{
    public Field2()
    {
        MasterStageParam master = DataManager.Instance.masterstage.list.Find(p => p.Stage_Name == "Field2");
        DataStageParam data = DataManager.Instance.datastage.list.Find(p => p.Stage_ID == master.Stage_ID);
        data.is_Open = true;
        DataManager.Instance.datastage.Save();
    }
}
