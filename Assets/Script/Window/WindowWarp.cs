using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowWarp : MonoBehaviour
{
    public Transform areaButton;
    private List<MasterStageParam> StageList = new List<MasterStageParam>();
    private List<GameObject> WarpPortalList = new List<GameObject>();
    private List<GameObject> DeleteObjectList = new List<GameObject>();

    private void OnEnable()
    {
        StageList = DataManager.Instance.masterstage.list;

        WarpPortalList.Clear();
        if (DeleteObjectList.Count > 0)
        {
            foreach(GameObject warp in DeleteObjectList)
            {
                Destroy(warp);
            }
            DeleteObjectList.Clear();
        }

        foreach(MasterStageParam q in StageList)
        {
            GameObject Warp = Instantiate(PrefabHolder.Instance.BtnWarp, areaButton) as GameObject;
            
            if (Warp.GetComponent<BtnWarp>().SetWarpTarget(q)) 
            {
                WarpPortalList.Add(Warp);
            }
            DeleteObjectList.Add(Warp);
            //Debug.Log(StageList.IndexOf(q));
        }
        EventSystem.current.SetSelectedGameObject(WarpPortalList[0]);

        for (int i = 0; i < WarpPortalList.Count; i++)
        {
            //Debug.Log("through");
            int num = i % 4;
            Button Btn = WarpPortalList[i].GetComponent<Button>();
            Navigation Navi = Btn.navigation;
            Navi.mode = Navigation.Mode.Explicit;
            int nextIndex = i + 1;
            int preIndex = i - 1;
            if (nextIndex < WarpPortalList.Count)
            {
                Navi.selectOnRight = WarpPortalList[nextIndex].GetComponent<Button>();
                //Debug.Log("get");
            }

            if (preIndex >= 0)
            {
                Navi.selectOnLeft = WarpPortalList[preIndex].GetComponent<Button>();
            }
            
            Btn.navigation = Navi;
        }
    }
}
