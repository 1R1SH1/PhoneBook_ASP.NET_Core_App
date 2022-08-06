using PhoneBook_ASP.NET_Core_App.Models.Classes;
using PhoneBook_ASP.NET_Core_App.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace PhoneBook_ASP.NET_Core_App.Models.Repository
{
    public class Storage : IRepository
    {
        private readonly List<Notes> _notes;
        private int _countId;
        private readonly Random _random = new Random();

        public Storage()
        {
            _countId = 1;
            _notes = new List<Notes>
            {
                new Notes
                {
                    Id = _countId++,
                    Name = "Марк",
                    SurName = "Аврелий",
                    Patronymic = "Юлийевич",
                    PhoneNumber = _random.Next(1000000, 9999999),
                    Address = "улица яблочная 1",
                    Information = "Римлянен"
                },
                new Notes
                {
                    Id = _countId++,
                    Name = "Геркулес",
                    SurName = "Гермес",
                    Patronymic = "Гераклович",
                    PhoneNumber = _random.Next(1000000, 9999999),
                    Address = "улица Яблочная 2",
                    Information = "Грек"
                },
                new Notes
                {
                    Id = _countId++,
                    Name = "Рагнар",
                    SurName = "Тор",
                    Patronymic = "Одинович",
                    PhoneNumber = _random.Next(1000000, 9999999),
                    Address = "улица Яблочная 3",
                    Information = "Норвежец"
                },
                new Notes
                {
                    Id = _countId++,
                    Name = "Афина",
                    SurName = "Хатшупсет",
                    Patronymic = "Зевсовна",
                    PhoneNumber = _random.Next(1000000, 9999999),
                    Address = "улица Яблочная 4",
                    Information = "Греко-Египтянка"
                },
                new Notes
                {
                    Id = _countId++,
                    Name = "Герадот",
                    SurName = "Хеопс",
                    Patronymic = "Горович",
                    PhoneNumber = _random.Next(1000000, 9999999),
                    Address = "улица Яблочная 5",
                    Information = "Греко-Египтянин"
                }
            };
        }

        public List<Notes> GetAll()
        {
            return _notes;
        }

        public Notes GetById(int id)
        {
            return _notes.Find(x => x.Id == id);
        }
    }
}
