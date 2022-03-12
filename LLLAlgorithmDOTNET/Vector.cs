using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Vector
{
    public List<double> basis = new List<double>();

    public Vector()
    {
    }

    public override string ToString()
    {
        string finalString = "";       

            for (int i = 0; i < basis.Count; i++)
            {
                if (i == 0)
                {
                    finalString = finalString + "(" + basis[i];
                }
                else if (i + 1 == basis.Count)
                {
                    finalString = finalString + ", " + basis[i] + ")";
                }
                else 
                {
                    finalString = finalString + ", " + basis[i];
                }
            }          
        return finalString;
    }

    public static double operator * (Vector vectorOne, Vector vectorTwo)
    {
        double suma = vectorOne.basis.Zip(vectorTwo.basis, (first, second) => first * second).Sum();
        return suma;
    }
    public static Vector operator * (Vector vector, double scalar)
    {
        Vector v = new Vector();
        v.basis = vector.basis.Select(c => c * scalar).ToList();
        return v;
    }

    public static Vector operator * (double scalar,Vector vector)
    {
        return vector * scalar;
    }

    public static Vector operator +(Vector vectorOne, Vector vectorTwo)
    {
        Vector v = new Vector();
        v.basis = vectorOne.basis.Zip(vectorTwo.basis, (first, second) => first + second).ToList();
        return v;
    }

   
    public static List<Vector> LLLAlgorithm(List<Vector> WorkingVectors)
    {
        int k = 1;

        List<Vector> GramSchmidtVectors = new List<Vector>();
        for (int n = 0; n < WorkingVectors.Count; n++)
        {
            GramSchmidtVectors.Add(new Vector());
        }

        while (k < WorkingVectors.Count)
        {
                GramSchmidtVectors = CreateGramSchmidtVectors(WorkingVectors, GramSchmidtVectors);

            for (int i = k - 1; i >= 0; i--)
            {                
                WorkingVectors[k] = ModifyVector(WorkingVectors[k], WorkingVectors, i, SizeReductionNumber(WorkingVectors[k], GramSchmidtVectors[i]));
                GramSchmidtVectors = CreateGramSchmidtVectors(WorkingVectors,GramSchmidtVectors);
            }

            if (LovasvCondition(GramSchmidtVectors[k - 1], GramSchmidtVectors[k], SizeReductionNumber(WorkingVectors[k], GramSchmidtVectors[k - 1])))
            {
                k = k + 1;
                if (k >= WorkingVectors.Count)
                {
                    break;
                }
            }
            else
            {
                WorkingVectors = SwapWorkingVectors(WorkingVectors, k);
                k = Math.Max(k - 1, 1);    
            }
        }
        return WorkingVectors;
    }

    public static double SizeReductionNumber(Vector vectorOne, Vector vectorTwo) ///DONE
    {
        return (vectorOne * vectorTwo) / (vectorTwo * vectorTwo);
    }
    public static Vector ModifyVector(Vector targetVector, List<Vector> WorkingVectors, int i,double SizeReductionNumber)
    {
        Vector suma = targetVector + (-1 * (WorkingVectors[i] * Math.Round(SizeReductionNumber)));            
        return suma;
    }


   
    public static bool LovasvCondition(Vector Ga, Vector Gb, double SizeReductionNumber)
    {
        if (Gb * Gb >= (0.75 - SizeReductionNumber * SizeReductionNumber) * (Ga * Ga))
        {
            return true;
        }
        return false;
    }
    public static List<Vector> CreateGramSchmidtVectors( List<Vector> WorkingVectors, List<Vector> GramSchmidtVectors) //https://www.youtube.com/watch?v=zHbfZWZJTGc
    {
        for (int n = 0; n < WorkingVectors.Count; n++)
        {           

            Vector suma = new Vector();
            suma.basis = WorkingVectors[n].basis;

            if (n != 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Vector meziVypocet = SizeReductionNumber(suma, GramSchmidtVectors[i]) * GramSchmidtVectors[i];
                    suma = suma + (-1 * meziVypocet);
                }                
            }
            GramSchmidtVectors[n] = suma;
        }
        return GramSchmidtVectors;
    }
    public static List<Vector> SwapWorkingVectors(List<Vector> WorkingVectors, int k)
    {
        List<Vector> NewWorkingVectors = WorkingVectors;
        Vector t = NewWorkingVectors[k - 1];
        NewWorkingVectors[k - 1] = NewWorkingVectors[k];
        NewWorkingVectors[k] = t;
        return NewWorkingVectors;
    }
}

