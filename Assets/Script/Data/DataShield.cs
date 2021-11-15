using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class DataShieldParam : CsvDataParam 
{
    public int Shield_ID;
	public bool Have;
	public bool Recipe_Have;
}

public class DataShild : CsvData<DataShieldParam>
{
	public void Add(int _Shield_ID)
	{
		DataShieldParam param = list.Find(p => p.Shield_ID == _Shield_ID);
		if (!param.Have)
		{
			param.Have = true;
		}
		Save();
	}

	public void CraftRecipe(int _Shield_ID)
    {
		DataShieldParam param = list.Find(p => p.Shield_ID == _Shield_ID);
		if (param == null)
		{
			param = new DataShieldParam()
			{
				Shield_ID = _Shield_ID,
				Have = false,
				Recipe_Have = false
			};
			list.Add(param);
		}
		Save();
	}
}
