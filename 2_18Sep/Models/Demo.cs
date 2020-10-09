using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _2_18Sep.Models
{
    public class Demo
    {
        public string FunctionA()
        {
            Thread.Sleep(2000);
            return "Hello";
        }
        public int FunctionB()
        {
            Thread.Sleep(5000);
            return new Random().Next();
        }
        public void FunctionC()
        {
            Thread.Sleep(3000);
            
        }
        public async Task<string> FunctionAAsync()
        {
            await Task.Delay(2000);
            return "Hello";
        }
        public async Task<int> FunctionBAsync()
        {
            await Task.Delay(5000);
            return new Random().Next();
        }
        public async Task FunctionCAsync()
        {
            await Task.Delay(3000);
            
        }
    }
}
