using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

	private int _currentDay;
	public int CurrentDay { get => _currentDay; set => _currentDay = value; }

	[Tooltip("Event to raise when day changes, sends the Current Day value too")]
	public static event Action<int> OnDayChange;

	[Tooltip("Event to raise when countdown for games end.")]
	public static event Action OnDaysEnd;

	[Tooltip("Give the maximum number of days the game will be played.")]
	[SerializeField]
	private int _totalDays = 7;

	[Tooltip("Give the maximum number of seconds the game day will be.")]
	[SerializeField]
	private const float _dayTimer = 600;

	private float _currentDayTime = 600;

	void Start()
	{
		_currentDayTime = _dayTimer;
		CurrentDay = _totalDays;
	}

	void Update()
	{
		if (CurrentDay <= 0)
			NotifyGameEndByDay();

		_currentDayTime -= Time.deltaTime;

		if (_currentDayTime <= 0)
			ChangeDay();

	}

	public void ChangeDay()
	{
		CurrentDay--;
		_currentDayTime = _dayTimer;
		NotifyDayChange();
	}

	private void NotifyGameEndByDay()
	{
		OnDaysEnd.Invoke();
	}

	private void NotifyDayChange()
	{
		OnDayChange.Invoke(CurrentDay);
	}
}
