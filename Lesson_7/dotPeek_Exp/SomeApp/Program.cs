// Decompiled with JetBrains decompiler
// Type: MSBuild.Program
// Assembly: SomeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 731679EC-BE7D-4B45-9157-428ED26C4E78
// Assembly location: E:\GeekBrains\Lesson_7\SomeApp\bin\Debug\net5.0\SomeApp.dll

using System;

namespace MSBuild
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.Write("Введи число, для пошагового двукратного увеличения: ");
      int int32 = Convert.ToInt32(Console.ReadLine());
      for (int index = 1; index < 6; ++index)
        Console.WriteLine(string.Format("Шаг №{0}, результат: {1}", (object) index, (object) (int32 *= 2)));
    }
  }
}
