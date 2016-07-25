using System;
using DotPlatform.AutoMapper;

namespace DotPlatform.Tests.AutoMapper.Dto
{
    public class Person_Test
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool Married { get; set; }
    }

    [AutoMapFrom(typeof(Person_Test))]
    public class PersonDesitination_Test
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool Married { get; set; }
    }
}
