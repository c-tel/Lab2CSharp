using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab2Telizhenko.Models
{
    public class JsonPersonRepository
    {
        private readonly FileInfo _fileInfo;
        public JsonPersonRepository(string filename)
        {
            _fileInfo = new FileInfo(filename);
            SeedStubsIfNeeded();
        }

        public IEnumerable<Person> Get()
        {
            string source;
            using (var stream = _fileInfo.OpenText())
            {
                source = stream.ReadToEnd();
            };
            return JsonConvert.DeserializeObject<IEnumerable<Person>>(source);
        }

        public void Put(IEnumerable<Person> people)
        {
            var serializedPeople = JsonConvert.SerializeObject(people);
            using (var stream = _fileInfo.CreateText())
            {
                stream.Write(serializedPeople);
            }
        }

        private void SeedStubsIfNeeded()
        {
            if (_fileInfo.Exists)
                return;
            var stubs = new Person[]
            {
                new Person("Mikhailo", "Petrenko", "my@ua", new DateTime(1998, 11, 11)),
                new Person("Foo", "Bar", "my1@ua", new DateTime(1995, 1, 1)),
                new Person("Tom", "Waits", "my2@ua", new DateTime(1960, 5, 5)),
                new Person("Petro", "Ivanenko", "my3@ua", new DateTime(1971, 12, 1)),
                new Person("John", "Doe", "my4@ua", new DateTime(1998, 11, 1)),
                new Person("Jason", "Funderburker", "my5@ua", new DateTime(2005, 2, 2)),
            };
            Put(stubs);
        }
    }
}
