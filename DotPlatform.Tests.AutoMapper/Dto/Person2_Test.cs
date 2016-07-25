using System;
using DotPlatform.AutoMapper;

namespace DotPlatform.Tests.AutoMapper.Dto
{
    [AutoMapTo(typeof(PersonDesitination2_Test))]
    public class Person2_Test
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool Married { get; set; }
    }

    public class PersonDesitination2_Test
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool Married { get; set; }
    }
}
