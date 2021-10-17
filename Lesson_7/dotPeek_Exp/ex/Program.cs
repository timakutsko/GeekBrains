// Decompiled with JetBrains decompiler
// Type: HelloWorld.Program
// Assembly: SomeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FE392E5-FEAA-4380-BA9E-354F5959F23D
// Assembly location: E:\GeekBrains\Lesson_7\ILDasm\ex.exe

using System;

namespace HelloWorld
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      string str = "some secret password";
      Console.WriteLine("Enter password:");
      if (!(Console.ReadLine() == str))
        return;
      Console.WriteLine("Welcome!");
    }
  }
}
