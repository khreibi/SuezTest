using System;
using Xunit;
using ConsoleApp1;
using System.Collections.Generic;
using NFluent;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void MagicTest(List<int> input, Dictionary<int,int> expected)
        {
            var result = Program.Magic(input);
            Check.That(result).Contains(expected);
        }


        public static IEnumerable<object[]> Data()
        {
            yield return new object[] {  
                new List<int> { 1, 2, 1 },
                new Dictionary<int, int> { 
                                            {1,0 },
                                            {2,0 },
                                            {3,1 }
                            } };
            yield return new object[] {
                new List<int> { 1,1,1,1, 2,2,2,2,2, 4 },
                new Dictionary<int, int> {
                    {1,0 },
                    {2,1 },
                    {3,1 },
                    {4,0 },
                    {5,1 }
                } 
            };

        }
    }
}
