using System;
using System.Collections;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace movezeros
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

            #if DEBUG
                var runner = new CustomTaskRunner();
                runner.ExecuteSample1();
                runner.ExecuteSample2();
                runner.ExecuteSample3();
            #endif
        }
    }

    public interface IActions
    {
        int[] Nums { get; set; }
        void Init(){
            Nums = new int[10] { 4, 2, 0, 0, 1, 6, 0, 3, 0, 7 };
        }

        void Run();

        void Results()
        {
            for (int i = 0; i < Nums.Length; i++)
            {
                Console.Write(Nums[i]);
            }
            Console.WriteLine();
        }
    }

    public class CustomTaskRunner
    {
        [Benchmark]
        public void ExecuteSample1()
        {
            CustomTaskRunner.Execute(new MoveZerosRight());
        }
        [Benchmark]
        public void ExecuteSample2()
        {
            CustomTaskRunner.Execute(new MoveNonZerosLeft());
        }
        [Benchmark]
        public void ExecuteSample3()
        {
            CustomTaskRunner.Execute(new FromGeeksForGeeks());
        }
        public static void Execute<T>(T action) where T : IActions
        {
            action.Init();
            action.Run();
            #if DEBUG
                action.Results();
            #endif
        }
    }

    public class FromGeeksForGeeks : IActions
    {
        public int[] Nums { get; set; }

        public void Run()
        {
            int count = 0;
            int n = Nums.Length;
            for (int i = 0; i < n; i++)
                if (Nums[i] != 0)
                    Nums[count++] = Nums[i];
    
            while (count < n)
                Nums[count++] = 0;
        }
    }

    public class MoveZerosRight : IActions
    {
        public int[] Nums { get; set; }

        public void Run()
        {
            int index = 0;
            int tempIndex = 0;
            while (index < Nums.Length - 1)
            {
                if (Nums[tempIndex] == 0)
                {
                    var temp = Nums[tempIndex];
                    Nums[tempIndex] = Nums[tempIndex + 1];
                    Nums[tempIndex + 1] = temp;
                }

                if (tempIndex < Nums.Length - 2)
                    tempIndex++;
                else
                    tempIndex = ++index;
            }
        }
    }
    public class MoveNonZerosLeft : IActions
    {
        public int[] Nums { get; set; }

        public void Run()
        {
            int currentNonZero = 0;
            int index = currentNonZero + 1;

            while (index < Nums.Length) { 
                if (Nums[currentNonZero] != 0) {
                    index = currentNonZero++ + 1;
                }
                else{
                    while (index < Nums.Length)
                    {
                        if(Nums[index] != 0){
                            var temp = Nums[currentNonZero];
                            Nums[currentNonZero] = Nums[index];
                            Nums[index] = temp;

                            index = currentNonZero++ + 1;
                        } else {
                            index++;
                        }
                    }
                }
            }
        }
    }
}

