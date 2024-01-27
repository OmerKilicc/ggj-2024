using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	[SerializeField]
	private int _totalDays = 7;

	[SerializeField]
	private const float _dayTimer = 600;

	private float _currentDayTime = 600;
	private int _currentDay;

	public static event Action<int> DayChanged;

	void Start()
	{
		_currentDayTime = _dayTimer;
		_currentDay = _totalDays;
	}

	void Update()
	{
		_currentDayTime -= Time.deltaTime;
		if (_currentDayTime <= 0)
		{
			ChangeDay();
		}
	}

	public void ChangeDay()
	{
		if (_currentDay > 0)
		{
			_currentDay--;
			_currentDayTime = _dayTimer;
			NotifyDayChange();
		}
	}

	private void NotifyDayChange()
	{
		DayChanged.Invoke(_currentDay);
	}
}
