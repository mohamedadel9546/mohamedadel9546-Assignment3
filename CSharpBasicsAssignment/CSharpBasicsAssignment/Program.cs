using System.Runtime.Serialization.Formatters;

namespace CSharpBasicsAssignment;

/* Part A :
(1. ROLES OF PROJECT FILES & FOLDERS:)
 .csproj: Floder contain the version to framework myproject ,metadata (TargetFramework) ,optionsc like (Nullable,ImplicitUsings)
Program.cs: this file conatain the code my project and main method which is entry point of the program
obj:Conain the temporary files and compiled files of the project
bin:Contains the final executable outputs (.exe, .dll) ready for running

(.csproj content:)
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>

 File Scoped:
Donot use the curly braces {} for the namespace and class declaration, use (;) instead od it,
and avoid the indenation of the namespace and class

State Project: use (sinx) in visual 2026 is the better than (sin) because it is more accurate 
and easy to read.
*/



class Program {
    //  Part B:
    static void RunTypesDemo()
    {
        int intValue = 1;       
        long longValue = 2;
        double doubleValue = 3.3;
        decimal decimalValue = 4.4m;
        bool boolValue = true;
        char charValue = 'A';
        string stringValue = "Hello, World!";
        var varValue = 5;
   Console.WriteLine(intValue.GetType()+" , "+ longValue.GetType()+" , "+ doubleValue.GetType()+" , "+"\n"
       + decimalValue.GetType()+" , "+ boolValue.GetType()+" , "+ "\n"+ charValue.GetType()+","+ 
       stringValue.GetType()+" , "+ varValue.GetType());
        Console.WriteLine("=======");
        //Implict Cast: this auto cast run when the right small left but isnot fixed rule
        int Value = 10;
        char charValue2 = 'B';
        long longValue2 = Value;
        Value = charValue2;
        Console.WriteLine(longValue2 + " , "+ Value);
        //Explict:this maneul convert because the right bigger than left lead to lose data when store in left
        //(Truncate vs Round) the Truncate cut the fraction number and store the real number use in explixt cast,
        //the round if the fraction number greather than (0.5) blus 1 use in (convert)
        double doubleValue2 =20.6;
        int intValue3 =(int)doubleValue2;//20
        int convertdouble = Convert.ToInt32(doubleValue2);//21
        Console.WriteLine(intValue3 + " , "+ convertdouble);
        //====
        //the first [(int/int)==int] ,the second [(double/int)==double] 
        Console.WriteLine($"5 / 2 : {5/2} , 5.0 / 2 : {5.0/2}");
        //Boxing/Unboxing
        int age = 25;
        object obj = age;//boxing
        Console.WriteLine($"age :{age} ,obj: {obj}");
        int coby = (int)obj;//unboxing
        Console.WriteLine($"age :{age} ,obj: {obj},coby: {coby} ");
        //parse,tryparse
        string goodstr = "123";
        string badstr = "abc";
        int pnum=int.Parse(goodstr);
        bool check = int.TryParse(badstr,out int res);
        if (check)
            Console.WriteLine("TryParse succeeded");
        else
            Console.WriteLine("TryParse Failed");

        //float → decimal: Implict Cast:the compiler refuse this cast because the decimal accurate,use base10 the float
        //use base2 and notaccurate
        //float flvalue = 50.5f;
        //decimal devalue =flvalue; 
        //Explict Cast
        //float flvalue = 50.5f;
        //decimal devalue =(decimal)flvalue; 

    }

    //Part C:
   // Experiment 1 — struct copy semantics
    //the p1,p2 is value type store in the stack the one of them store the content yourself
    //the p2 take the copy (Values) from p1 and the p2 is change not affect in p1
    struct Point { public int X; public int Y; }

   // Experiment 2 — class reference semantics(Order class)
   public class Order {
       public int OrderId, Quantity;
        public string CustomerName, ShippingCity;
        public decimal UnitPrice, TotalPrice;
        public bool IsPaid ;
        public double DiscountPercent;
        public char Priority;
        public long ItemCode;

        public decimal CalculateTotal()//Method 1
        {
            decimal reslut = Convert.ToDecimal((1 - (DiscountPercent / 100)));
            TotalPrice =( Quantity * UnitPrice* reslut);
            return TotalPrice;
        }

        public void PrintSummary()
        {
            Console.WriteLine($"Id :{OrderId}, Name: {CustomerName}, TotalPrice: {TotalPrice}, IsPaid: {IsPaid}");
        }
    }
    //End Part C : any (struct,enum) store in the stack because value type, any (class,interface,string)
    //store in the heap and teh refrence in the stack . the object is the refrence type store in the stack not create object in the heap.
   
   
    static void Main(string[] args)
    {
        //RunTypesDemo();
       
        //Point p1 = new Point { X = 1, Y = 2 }; 
        //Point p2 = p1;
        //p2.X = 99;
        //Console.WriteLine($"P1.x: {p1.X} , P2.X: {p2.X}");

        Order o1 = new Order
        {
            CustomerName = "Gaser",
            Quantity = 2,
            OrderId = 1,
            IsPaid = false,
            ItemCode = 123,
            UnitPrice = 50,
            Priority = 'G',
            DiscountPercent = 50,
            ShippingCity="Mansoura",      
        };
        o1.CalculateTotal();
        Order o2 = o1;
        o2.IsPaid = true;
        Console.WriteLine($"o1.ispaid: {o1.IsPaid},  o2.IsPaid: {o2.IsPaid}");//o1,o2 ispaid =true because the two refrence is the same object in the heap 
        //that is it the any of them change in object and reflect in the other
        object boxedOrder = o1;
        Order o3 = (Order)boxedOrder;
        Console.WriteLine(object.Equals(o3, boxedOrder));
        o2.PrintSummary();
        //Part D:
        //D1 — Scope:
        int t1 = 50;//private filed
      void test1() { t1 = 100; }
      void test2() { t1 = 200; }

      void test3() { int count1 = 0;}//Local Varible

        for (int i = 0; i < 5; i++)
        {
            int count2 = 500;//Block varible
        }
        int total = 100;
        total += 50;
        Console.WriteLine($"Total (+): {total}");
        total -= 50;
        Console.WriteLine($"Total (-): {total}");
        total *= 50;
        Console.WriteLine($"Total (*): {total}");
        total /= 50;
        Console.WriteLine($"Total (/): {total}");
        total %= 50;
        Console.WriteLine($"Total (%): {total}");
        //D3 — Bitwise operators (not logical operators)
        //When the left operand is false, the logical operator && short -
        //circuits and skips evaluating the right operand, whereas the bitwise operator
        // & evaluates both operands regardle
        int a = 12; 
        int b = 10;
        Console.WriteLine($"&: {a & b}, |: {a | b},^: {a ^ b}");

     
       
    }

}












