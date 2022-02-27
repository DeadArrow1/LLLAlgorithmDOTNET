using System.Linq;


namespace LLLAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //2 Dimensional test values

            //b0 47 215
            //b1 95 460

            //b0 201 37
            //b1 1648 297

            //3 Dimensional test values b0= 1;1;1 b1=-1;0;2 b2=3;5;6
            //3 Dimensional test values b0= 1;-1;1 b1=1;0;1 b2=1;1;2

            var OurWorkingVectors = new List<OurVector>() 
            {
             new OurVector() {basis = {1 , 1, 1}},
             new OurVector() {basis = {-1, 0, 2}},
             new OurVector() {basis = {3 , 5, 6}},
            };
                       

            OurVector.LLLAlgorithm(OurWorkingVectors);


            Console.ReadKey();

        }
    }

}


