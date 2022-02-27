using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OurVector
{
    public List<double> basis = new List<double>();

    public OurVector()
    {
    }

    public static double Multiply(OurVector a, OurVector b)
    {

        double suma = a.basis.Zip(b.basis, (first, second) => first * second).Sum();
        return suma;
    }

    public static OurVector Multiply(OurVector a, double j)
    {
        OurVector v = new OurVector();
        v.basis = a.basis.Select( c => c * j).ToList();
        return v;
    }

    public static OurVector Multiply(double j, OurVector a)
    {
        return Multiply(a, j);
    }

    public static OurVector Subtract(OurVector a, OurVector b)
    {
        OurVector v = new OurVector();
        OurVector Reducer = new OurVector();
        Reducer.basis = b.basis.Select( c => c * (-1)).ToList();
        v = Addition(a, Reducer);
        return v;
    }

    public static OurVector Addition(OurVector a, OurVector b)
    {
        OurVector v = new OurVector();
        v.basis = a.basis.Zip(b.basis, (first, second) => first + second).ToList();
        return v;
    }

    public static OurVector Division(OurVector vector, double scalar)
    {
        OurVector v = new OurVector();
        v.basis = vector.basis.Select(c => { c = c * 1 / scalar; return c; }).ToList();
        return v;
    }
    public static List<OurVector> LLLAlgorithm(List<OurVector> OurWorkingVectors)
    {
        int k = 1;
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

        List<OurVector> OurGramSchmidtVectors = new List<OurVector>();
        double u;
        for (int n = 0; n < OurWorkingVectors.Count; n++)
        {
            OurGramSchmidtVectors.Add(new OurVector());
        }

        while (k < OurWorkingVectors.Count)
        {
            for (int n = 0; n < OurWorkingVectors.Count; n++)
            {
                OurGramSchmidtVectors[n] = OurGramSchmidtReduction(OurWorkingVectors[n], n, OurGramSchmidtVectors, OurWorkingVectors);
            }

            

            for (int i = k - 1; i >= 0; i--)
            {
                u = OurSizeCondition(OurWorkingVectors[k], OurGramSchmidtVectors[i]);
                if (u > 0.5)
                {
                    OurWorkingVectors[k] = OurModifyVector(k, OurWorkingVectors, u, i);
                }
                
            }

            u = OurSizeCondition(OurWorkingVectors[k], OurGramSchmidtVectors[k - 1]);
            if (OurLovasvCondition(OurGramSchmidtVectors[k - 1], OurGramSchmidtVectors[k], u))
            {
                //Console.WriteLine("true");
                k = k + 1;
                if (k >= OurWorkingVectors.Count)
                {
                    break;
                }
            }
            else
            {
                OurWorkingVectors = OurSwapWorkingVectors(OurWorkingVectors, k);
                k = Math.Max(k - 1, 1);    
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

        return OurWorkingVectors;
    }

    public static double OurSizeCondition(OurVector va, OurVector vb)
    {
        return Math.Abs((OurVector.Multiply(va, vb)) / (OurVector.Multiply(vb, vb)));
    }
    public static OurVector OurModifyVector(int k, List<OurVector> OurWorkingVectors, double u, int i)
    {

        OurVector suma = OurVector.Subtract(OurWorkingVectors[k], OurVector.Multiply(OurWorkingVectors[i], Math.Round(u)));
             
        return suma;
    }


    /*public static OurVector OurModifyVector(OurVector va, OurVector vb, double vu)
    {
        va = OurVector.Subtract(va, OurVector.Multiply(vb, Math.Round(vu)));
        return va;
    }*/
    public static bool OurLovasvCondition(OurVector Ga, OurVector Gb, double u)
    {
        if ((Gb.basis[0] * Gb.basis[0] + Gb.basis[1] * Gb.basis[1]) >= (0.75 - u * u) * Ga.basis[0] * Ga.basis[0] + Ga.basis[1] * Ga.basis[1])
        {
            return true;
        }
        return false;
    }
    public static OurVector OurGramSchmidtReduction(OurVector va, int n, List<OurVector> OurGramSchmidtVectors, List<OurVector> OurWorkingVectors) //https://www.youtube.com/watch?v=zHbfZWZJTGc
    {
        OurVector suma = new OurVector();
        suma.basis = va.basis;
        /*for (int i = 0; i < va.basis.Count; i++)
        {
            suma.basis.Add(va.basis[i]);
        }*/
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
                OurVector meziVypocet = OurVector.Multiply(citatel / jmenovatel, OurGramSchmidtVectors[i]);
                suma = OurVector.Subtract(suma, meziVypocet);
            }

            for (int i = 0; i < va.basis.Count; i++)
            {
                suma.basis[i] = Math.Round(suma.basis[i], 2);
            }
            return suma;
        }
    }
    public static List<OurVector> OurSwapWorkingVectors(List<OurVector> OurWorkingVectors, int k)
    {
        List<OurVector> OurNewWorkingVectors = OurWorkingVectors;
        OurVector t = OurNewWorkingVectors[k - 1];
        OurNewWorkingVectors[k - 1] = OurNewWorkingVectors[k];
        OurNewWorkingVectors[k] = t;
        return OurNewWorkingVectors;
    }
}

