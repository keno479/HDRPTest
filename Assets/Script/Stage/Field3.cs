using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field3 : MonoBehaviour
{
    public Field3()
    {
        MasterStageParam master = DataManager.Instance.masterstage.list.Find(p => p.Stage_Name == "Field3");
        DataStageParam data = DataManager.Instance.datastage.list.Find(p => p.Stage_ID == master.Stage_ID);
        data.is_Open = true;
        DataManager.Instance.datastage.Save();
    }
}
