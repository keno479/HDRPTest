using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowWarp : MonoBehaviour
{
    public Transform areaButton;
    private List<MasterStageParam> StageList = new List<MasterStageParam>();
    private List<GameObject> WarpPortalList = new List<GameObject>();

    private void OnEnable()
    {
        StageList = DataManager.Instance.masterstage.list;

        if (WarpPortalList.Count > 0)
        {
            foreach(GameObject warp in WarpPortalList)
            {
                Destroy(warp);
            }
            WarpPortalList.Clear();
        }

        foreach(MasterStageParam q in StageList)
        {
            GameObject Warp = Instantiate(PrefabHolder.Instance.BtnWarp, areaButton) as GameObject;
            Warp.GetComponent<BtnWarp>().SetWarpTarget(q);
            WarpPortalList.Add(Warp);
            Debug.Log(StageList.IndexOf(q));
        }
    }
}
