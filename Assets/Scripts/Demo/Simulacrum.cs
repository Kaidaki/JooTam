using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace simula
{
	public interface IObserver
	{
		void pushAlarm(string title, string news);
	}

	public interface IPublisher
	{
		void addObserver(IObserver observer);
		void removeObserver(IObserver observer);
		void notify();
	}

	//real 발행자
	public class NewsMachine : IPublisher
	{
		List<IObserver> observers;
		public string title { get; private set; }
		public string news { get; private set; }

		public NewsMachine()
		{
			observers = new List<IObserver>();
		}

		public void addObserver(IObserver observer)
		{
			observers.Add(observer);
		}

		public void removeObserver(IObserver observer)
		{
			int index = observers.IndexOf(observer);
			observers.RemoveAt(index);
		}

		public void notify()
		{
			foreach(IObserver observer in observers)
			{
				observer.pushAlarm(title, news);
			}
		}

		public void setNewsInfo(string title, string news)
		{
			this.title = title;
			this.news = news;
			notify();
		}
	}

	//real 감시자
	public class AnnualSubscriber : IObserver
	{
		string newsString;
		IPublisher publisher;

		public AnnualSubscriber(IPublisher publisher)
		{
			this.publisher = publisher;
			publisher.addObserver(this);
		}

		public void pushAlarm(string title, string news)
		{
			this.newsString = title + " :: " + news;
			printNews();
		}

		public void printNews()
		{
			Debug.Log("todays news!" + newsString);
		}
	}



	public class Simulacrum : MonoBehaviour
	{
		/*
		public event Handler Event;  // 생략형

		private Handler _Event; // _Event라는 delegate 변수를 자동으로 만들어냅니다.
		public event Handler Event
		{
			add
			{
				lock (this) { _Event += value; }
			}

			remove
			{
				lock (this) { _Event -= value; }
			}
		}*/

		// Use this for initialization
		void Start()
		{
			NewsMachine sbsNews = new NewsMachine();
			AnnualSubscriber man0 = new AnnualSubscriber(sbsNews);


			sbsNews.setNewsInfo("1st News", "ITs COOOL");
		}
	}
}