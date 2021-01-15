using System;
using System.Collections.Generic;

namespace accounting
{
    [Serializable]
    public class DataStorage
    {
        public List<Person> persons;

        public DataStorage()
        {
            persons = new List<Person>();
        }
    }

    [Serializable]
    public class Person
    {
        public string name;
        public List<Date> dates;

        public Person()
        {
            dates = new List<Date>();
        }

        public Person(string name)
        {
            this.name = name;
            dates = new List<Date>();
        }
    }

    [Serializable]
    public class Date
    {
        public DateTime date;
        public List<int> incomePerDay;
        public List<int> costsPerDay;

        public Date()
        {
            incomePerDay = new List<int>();
            costsPerDay = new List<int>();
        }

        public Date(DateTime date)
        {
            this.date = date;
            incomePerDay = new List<int>();
            costsPerDay = new List<int>();
        }
    }
}
