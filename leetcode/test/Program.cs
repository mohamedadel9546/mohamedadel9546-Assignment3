

class Program
{
    //Part F:Leet code problem
    static int FindSingleNumber(int[] nums)
    {
        //time : o(n)
        //space : o(1)
        int res = 0;
        foreach (var num in nums)
        {
            res ^= num;
        }
        return res;
    }
    static void Main(string[] args)
    {

        int[] nums = { 11, 12, 11, 12, 28 };
        int res = FindSingleNumber(nums);
        Console.WriteLine(res);
    }
}	

