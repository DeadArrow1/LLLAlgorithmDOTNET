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


            List<OurVector> OurWorkingVectors = new List<OurVector>();

            OurWorkingVectors.Add(new OurVector());
            OurWorkingVectors[0].basis.Add(47);
            OurWorkingVectors[0].basis.Add(215);
            //OurWorkingVectors[0].basis.Add(1);

            OurWorkingVectors.Add(new OurVector());
            OurWorkingVectors[1].basis.Add(95);
            OurWorkingVectors[1].basis.Add(460);
            //OurWorkingVectors[1].basis.Add(2);

            /*OurWorkingVectors.Add(new OurVector());
            OurWorkingVectors[2].basis.Add(3);
            OurWorkingVectors[2].basis.Add(5);
            OurWorkingVectors[2].basis.Add(6);*/

            OurVector.LLLAlgorithm(OurWorkingVectors);


            Console.ReadKey();

        }
    }

}


