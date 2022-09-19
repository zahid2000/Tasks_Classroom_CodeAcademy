using Exception;
using Microsoft.CSharp.RuntimeBinder;

dynamic a = "nhh";
//Console.WriteLine(typeof(DivideByZeroException));
try
{
    int num = a;
    int num1 = 5;
    int num2 = 0;
    int num3 = num1 / num2;

    int[] arr = new int[0];
    arr[0] = 7;
}
catch (System.Exception e) when (e.GetType() != typeof(RuntimeBinderException) && e.GetType() != typeof(DivideByZeroException))
{
    Console.WriteLine("Error");
}
catch (DivideByZeroException e)
{

    Console.WriteLine("0 a bole bilmezsiz");


}
catch (RuntimeBinderException e)
{
    Console.WriteLine("Incorrect cast ");
    throw new CustomException("Error");
}
finally
{
    Console.WriteLine("Finally block is read");
}




