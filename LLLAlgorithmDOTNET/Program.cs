using System;
using System.Collections.Generic;
using System.Windows;

namespace LLLAlgorithm
{
    class Program
    {
        public class OurVector
        {
            public List<double> basis = new List<double>();

            public OurVector()
            {
            }

            public static double Multiply(OurVector a, OurVector b)
            {
                double suma = 0;
                for (int i = 0; i < a.basis.Count; i++)
                {
                    double multiplication = a.basis[i] * b.basis[i];
                    suma = suma + multiplication;
                }
                return suma;
            }

            public static OurVector Multiply(OurVector a, double j)
            {
                OurVector v = new OurVector();
                for (int i = 0; i < a.basis.Count; i++)
                {
                    v.basis.Add(a.basis[i] * j);

                }
                return v;
            }

            public static OurVector Multiply(double j, OurVector a)
            {
                OurVector v = new OurVector();
                for (int i = 0; i < a.basis.Count; i++)
                {
                    v.basis.Add(a.basis[i] * j);

                }
                return v;
            }

            public static OurVector Subtract(OurVector a, OurVector b)
            {
                OurVector v = new OurVector();


                for (int i = 0; i < a.basis.Count; i++)
                {
                    v.basis.Add(a.basis[i] - b.basis[i]);
                }
                return v;
            }

            public static OurVector operator /(OurVector vector, double scalar)
            {
                for (int i = 0; i < vector.basis.Count; i++)
                {
                    vector.basis[i] = vector.basis[i] / scalar;

                }

                return vector;
            }
        }


        static void Main(string[] args)
        {
            //2 Dimensional test values

            //b0 47 215
            //b1 95 460

            //b0 201 37
            //b1 1648 297

            //3 Dimensional test values b0= 1;1;1 b1=-1;0;2 b2=3;5;6
            //3 Dimensional test values b0= 1;-1;1 b1=1;0;1 b2=1;1;2

            int k = 1;
            List<OurVector> OurWorkingVectors = new List<OurVector>();
            List<OurVector> OurGramSchmidtVectors = new List<OurVector>();

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



            Console.WriteLine("Our bases are:");
            for (int i = 0; i < OurWorkingVectors.Count; i++)
            {
                int j = 0;
                string vector = "";
                while (j < OurWorkingVectors[i].basis.Count)
                {
                    if (j == 0)
                    {
                        vector = vector + OurWorkingVectors[i].basis[j].ToString();
                    }
                    else
                    {
                        vector = vector + " ; " + OurWorkingVectors[i].basis[j].ToString();
                    }

                    j++;
                }
                Console.WriteLine(vector);
            }

            double u10;
            for (int n = 0; n < OurWorkingVectors.Count; n++)
            {
                /*if (n == 0)
                {*/
                //OurGramSchmidtVectors.Add(new OurVector());
                //OurGramSchmidtVectors[n] = OurWorkingVectors[n];
                /*}
                else
                {*/
                OurGramSchmidtVectors.Add(new OurVector());
                OurGramSchmidtVectors[n] = OurGramSchmidtReduction(OurWorkingVectors[n], n);
                //}

            }

            /*OurGramSchmidtVectors.Add(new OurVector());
            OurGramSchmidtVectors[0] = OurWorkingVectors[0];
            OurGramSchmidtVectors.Add(new OurVector());
            OurGramSchmidtVectors[1] = OurGramSchmidtReduction(OurWorkingVectors[1]);
            OurGramSchmidtVectors.Add(new OurVector());
            OurGramSchmidtVectors[2] = OurGramSchmidtReduction(OurWorkingVectors[2]);*/




            while (k < OurWorkingVectors.Count)
            {


                u10 = OurSizeCondition(OurWorkingVectors[k], OurGramSchmidtVectors[k - 1]);  //b1,Gb0           
                Console.WriteLine(u10);
                if (u10 >= 0.5)
                {

                    OurWorkingVectors[k] = OurModifyVector(OurWorkingVectors[k], OurWorkingVectors[k - 1], u10);


                }
                u10 = OurSizeCondition(OurWorkingVectors[k], OurGramSchmidtVectors[k - 1]);

                if (OurLovasvCondition(OurGramSchmidtVectors[k - 1], OurGramSchmidtVectors[k], u10))
                {
                    Console.WriteLine("true");
                    k = k + 1;
                    if (k >= OurWorkingVectors.Count)
                    {
                        break;
                    }
                }
                else
                {

                    OurSwapWorkingVectors();
                    k = Math.Max(k - 1, 1);
                    for (int n = 0; n < OurWorkingVectors.Count; n++)
                    {
                        if (n == 0)
                        {
                            OurGramSchmidtVectors.Add(new OurVector());
                            OurGramSchmidtVectors[n] = OurWorkingVectors[n];
                        }
                        else
                        {
                            OurGramSchmidtVectors.Add(new OurVector());
                            OurGramSchmidtVectors[n] = OurGramSchmidtReduction(OurWorkingVectors[n], n);
                        }

                    }
                }


            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Our reduced bases are:");
            for (int i = 0; i < k; i++)
            {
                int j = 0;
                string vector = "";
                while (j < OurWorkingVectors.Count)
                {
                    if (j == 0)
                    {
                        vector = vector + OurWorkingVectors[i].basis[j].ToString();
                    }
                    else
                    {
                        vector = vector + " ; " + OurWorkingVectors[i].basis[j].ToString();
                    }

                    j++;
                }
                Console.WriteLine(vector);
            }






            Console.ReadKey();



            double OurSizeCondition(OurVector va, OurVector vb)
            {
                return Math.Abs((OurVector.Multiply(va, vb)) / (OurVector.Multiply(vb, vb)));
            }


            OurVector OurModifyVector(OurVector vb, OurVector va, double vu)
            {
                vb = OurVector.Subtract(vb, OurVector.Multiply(va, Math.Round(vu)));
                return vb;
            }



            bool OurLovasvCondition(OurVector Ga, OurVector Gb, double u)
            {
                double levaStrana = Gb.basis[0] * Gb.basis[0] + Gb.basis[1] * Gb.basis[1];
                double pravaStrana = (0.75 - u * u) * (Ga.basis[0] * Ga.basis[0] + Ga.basis[1] * Ga.basis[1]);



                if ((Gb.basis[0] * Gb.basis[0] + Gb.basis[1] * Gb.basis[1]) >= (0.75 - u * u) * Ga.basis[0] * Ga.basis[0] + Ga.basis[1] * Ga.basis[1])
                {
                    return true;
                }
                return false;
            }


            OurVector OurGramSchmidtReduction(OurVector va, int n) //https://www.youtube.com/watch?v=zHbfZWZJTGc
            {


                OurVector suma = new OurVector();
                for (int i = 0; i < va.basis.Count; i++)
                {
                    suma.basis.Add(va.basis[i]);

                }
                if (n == 0)
                {
                    return va;
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        double citatel = OurVector.Multiply(va, OurGramSchmidtVectors[i]);
                        double jmenovatel = OurVector.Multiply(OurGramSchmidtVectors[i], OurGramSchmidtVectors[i]);
                        OurVector mezivypocet = OurVector.Multiply(citatel / jmenovatel, OurGramSchmidtVectors[i]);


                        suma = OurVector.Subtract(suma, mezivypocet);

                        //suma = OurVector.Subtract(suma, OurVector.Multiply(OurVector.Multiply(va, OurGramSchmidtVectors[i]), OurWorkingVectors[i]) / OurVector.Multiply(OurGramSchmidtVectors[i], OurGramSchmidtVectors[i]));

                    }
                    //OurVector vb = OurVector.Subtract(va, OurVector.Multiply(OurVector.Multiply(va, OurGramSchmidtVectors[n - 1]), OurWorkingVectors[n - 1]) / OurVector.Multiply(OurGramSchmidtVectors[n - 1], OurGramSchmidtVectors[n - 1]));
                    for (int i = 0; i < va.basis.Count; i++)
                    {
                        suma.basis[i] = Math.Round(suma.basis[i], 2);
                    }


                    return suma;
                }
            }

            void OurSwapWorkingVectors()
            {
                OurVector t = OurWorkingVectors[k - 1];
                OurWorkingVectors[k - 1] = OurWorkingVectors[k];
                OurWorkingVectors[k] = t;
            }
        }
    }

}
