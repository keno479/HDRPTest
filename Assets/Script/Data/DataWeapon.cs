using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;
public class DataWeaponParam : CsvDataParam
{
	public int Weapon_ID;
	public int Num;
	public int Weapon_LV;

	public int craft_count;
}
public class DataWeapon : CsvData<DataWeaponParam>
{
	public void Add(int _iWeaponId)
	{
		DataWeaponParam param = list.Find(p => p.Weapon_ID == _iWeaponId);
		if (param != null)
		{
			param.Num += 1;
		}
		else
		{
			param = new DataWeaponParam()
			{
				Weapon_ID = _iWeaponId,
				Num = 1,
				Weapon_LV = 1
			};
			list.Add(param);
		}
	}
}
