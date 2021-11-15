using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class DataItemParam : CsvDataParam
{
	public int Item_ID;
	public int Num;

	public int craft_count;
}
public class DataItem : CsvData<DataItemParam>
{
	public void Add(int _iItemId)
	{
		DataItemParam param = list.Find(p => p.Item_ID == _iItemId);
		if (param != null)
		{
			param.Num += 1;
		}
		else
		{
			param = new DataItemParam()
			{
				Item_ID = _iItemId,
				Num = 1
			};
			list.Add(param);
		}
	}
}
