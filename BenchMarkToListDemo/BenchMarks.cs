using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchMarkToListDemo
{

    [MemoryDiagnoser]
    public class Example1
    {
        [Params(10, 100000)]
        public int count { get; set; }

        private int[] array;

        [GlobalSetup]
        public void Setup()
        {
            array = Enumerable.Range(1, count).ToArray();
        }


        [Benchmark(Baseline = true)]
        public void ToListDotGreaterThanZero()
        {
            if (array.Where(x => x == 4).ToList().Count > 0)
            {
            }
        }

        [Benchmark]
        public void WhereCounttGreaterThanZero()
        {
            if (array.Where(x => x == 4).Count() > 0)
            {
            }
        }

        [Benchmark]
        public void LinqWhereDotAny()
        {
            if (array.Where(x => x == 4).Any())
            {

            }
        }

        [Benchmark]
        public void LinqAny()
        {
            if (array.Any(x => x == 4))
            {

            }
        }
    }


    [MemoryDiagnoser]
    public class Example2
    {
        public string Value = "key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2;key:value;key:value2";

        [Benchmark(Baseline = true)]
        public void UsingToList()
        {
            var list = Value.Split(";").ToList();

                foreach (var item in list)
                {
                    var itemInfo = item.Split(":").ToList();
                    if (itemInfo.Count == 2 && itemInfo[0] == "key")
                    {
                    }
                }
        }

        [Benchmark]
        public void WithoutToList()
        {
            var list = Value.Split(";");

            foreach (var item in list)
            {
                var itemInfo = item.Split(":");
                if (itemInfo.Count() == 2 && itemInfo[0] == "key")
                {
                }
            }
        }
    }


    [MemoryDiagnoser]
    public class Example3
    {
        [Params(10, 100000)]
        public int count { get; set; }

        private List<int> array;

        [GlobalSetup]
        public void Setup()
        {
            array = Enumerable.Range(1, count).ToList();
        }


        [Benchmark(Baseline = true)]
        public void ToListDotForFeach()
        {
            array.OrderByDescending(x => x).ToList().ForEach(item =>
            {
                // Do something...
            });
        }

        [Benchmark]
        public void Foreach()
        {
            foreach (var item in array.OrderByDescending(x => x))
            {
                // Do something...
            }
        }
    }


}
