using System;

namespace DotPlatform.AutoMapper.Tests
{
   
    public class DtoPerson_Test
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool Married { get; set; }
    }

    [AutoMapFrom(typeof(DtoPerson_Test))]
    public class DtoPersonDesitination_Test
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool Married { get; set; }
    }

    public class DtoPerson2_Test
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool Married { get; set; }
    }

    public class DtoPersonDesitination2_Test
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public bool Married { get; set; }
    }
}
