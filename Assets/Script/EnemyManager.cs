using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class EnemyManager : Singleton<EnemyManager>
{
	public List<EnemyController> EnemyList
	{
		get { return EnemyControllerList; }
	}
	private List<EnemyController> EnemyControllerList = new List<EnemyController>();
	public override void Initialize()
	{
		base.Initialize();
	}
	public void Add(EnemyController _monster)
	{
		EnemyControllerList.Add(_monster);
	}

}