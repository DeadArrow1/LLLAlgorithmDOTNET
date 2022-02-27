using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class OurVectorTests
    {
        [TestMethod()]
        public void OurSwapWorkingVectorsTest1()
        {
            var StartingVectors = new List<OurVector>()
            {
             new OurVector() {basis = {47, 215}},
             new OurVector() {basis = {95, 460}},
            };

            var CorrectVectors = new List<OurVector>()
            {
             new OurVector() {basis = {95, 460}},
             new OurVector() {basis = {47, 215}},
            };

            OurVector.OurSwapWorkingVectors(StartingVectors, 1);


            if (Enumerable.SequenceEqual(StartingVectors[0].basis, CorrectVectors[0].basis)
                &&
                Enumerable.SequenceEqual(StartingVectors[1].basis, CorrectVectors[1].basis))
            {
                return;
            }
            Assert.Fail("Lists of vectors do not match.");
            return;
        }

        [TestMethod()]
        public void OurSwapWorkingVectorsTest2()
        {
            var StartingVectors = new List<OurVector>()
            {
             new OurVector() {basis = {47, 215}},
             new OurVector() {basis = {95, 460}},
             new OurVector() {basis = {5, 42}},
            };

            var CorrectVectors = new List<OurVector>()
            {
             new OurVector() {basis = {47, 215}},
             new OurVector() {basis = {5, 42}},
             new OurVector() {basis = {95, 460}},
            };

            OurVector.OurSwapWorkingVectors(StartingVectors, 2);


            if (Enumerable.SequenceEqual(StartingVectors[1].basis, CorrectVectors[1].basis)
                &&
                Enumerable.SequenceEqual(StartingVectors[2].basis, CorrectVectors[2].basis))
            {
                return;
            }
            Assert.Fail("Lists of vectors do not match.");
            return;
        }

        [TestMethod()]
        public void OurSizeConditionTest1()
        {
            OurVector a = new OurVector() { basis = { 95, 460 } };
            OurVector b = new OurVector() { basis = { 47, 215 } };

            double Result = OurVector.OurSizeCondition(a, b);

            if (Result >= 0.5)
            {
                return;
            }
            Assert.Fail("Condition (Result >= 0.5) is not satisfied");
            return;
        }

        [TestMethod()]
        public void OurSizeConditionTest2()
        {
            OurVector a = new OurVector() { basis = { 1, 30 } };
            OurVector b = new OurVector() { basis = { 40, 5 } };

            double Result = OurVector.OurSizeCondition(a, b);

            if (Result < 0.5)
            {
                return;
            }
            Assert.Fail("Condition (Result < 0.5) is not satisfied");
            return;
        }

        public static OurVector OurModifyVector(int k, List<OurVector> OurWorkingVectors, double u, int i)
        {

            OurVector suma = OurVector.Subtract(OurWorkingVectors[k], OurVector.Multiply(OurWorkingVectors[i], Math.Round(u)));

            return suma;
        }

        [TestMethod()]
        public void OurModifyVectorTest()
        {
            int k = 1;
            int i = 0;
            double u = 2.33;

            var StartingVectors = new List<OurVector>()
            {
             new OurVector() {basis = {47, 215}},
             new OurVector() {basis = {95, 460}},
            };

            OurVector Result = OurVector.OurModifyVector(k, StartingVectors, u, i);
            OurVector CorrectResult = new OurVector() { basis = { 1, 30 } };

            if (Result.basis[0] == CorrectResult.basis[0] && Result.basis[1] == CorrectResult.basis[1])
            {
                return;
            }
            Assert.Fail("Result and CorrectResult do not match in condition (Result.basis == CorrectResult.basis)");
        }

        [TestMethod()]
        public void OurLovasvConditionTest1()
        {
            OurVector Ga = new OurVector() { basis = { 47, 215 } };
            OurVector Gb = new OurVector() { basis = { -5.3, 1.16 } };
            double u = 0.13414130569434696;

            bool result = OurVector.OurLovasvCondition(Ga, Gb, u);
            bool expectedResult = false;

            if (result == expectedResult)
            {
                return;
            }


            Assert.Fail("Condition failed");
        }

        [TestMethod()]
        public void OurLovasvConditionTest2()
        {
            OurVector Ga = new OurVector() { basis = { 1, 30 } };
            OurVector Gb = new OurVector() { basis = { 39.79, -1.33 } };
            double u = 0.21087680355160932;

            bool result = OurVector.OurLovasvCondition(Ga, Gb, u);
            bool expectedResult = true;

            if (result == expectedResult)
            {
                return;
            }

            Assert.Fail("Condition failed");
        }

        [TestMethod()]
        public void OurGramSchmidtReductionTest()
        {
            var StartingVectors = new List<OurVector>()
            {
             new OurVector() {basis = {47, 215}},
             new OurVector() {basis = {95, 460}},
            };

            List<OurVector> OurGramSchmidtVectors = new List<OurVector>();
            List<OurVector> CorrectGramSchmidtVectors = new List<OurVector>(){
             new OurVector() {basis = {47, 215}},
             new OurVector() {basis = {-5.3, 1.16}},
            };
            
            for (int n = 0; n < StartingVectors.Count; n++)
            {
                OurGramSchmidtVectors.Add(new OurVector());
                OurGramSchmidtVectors[n] = OurVector.OurGramSchmidtReduction(StartingVectors[n], n, OurGramSchmidtVectors, StartingVectors);
            }

            if (OurGramSchmidtVectors[0].basis[0] == CorrectGramSchmidtVectors[0].basis[0]
                &&
                OurGramSchmidtVectors[0].basis[1] == CorrectGramSchmidtVectors[0].basis[1]
                &&
                OurGramSchmidtVectors[1].basis[0] == CorrectGramSchmidtVectors[1].basis[0]
                &&
                OurGramSchmidtVectors[1].basis[1] == CorrectGramSchmidtVectors[1].basis[1])
            {
                return;
            }
            Assert.Fail("Lists of vectors do not match.");
        }

        [TestMethod()]
        public void MultiplyTest1()
        {
            OurVector va = new OurVector() { basis = { 2, 5 } };
            OurVector vb = new OurVector() { basis = { 3, 8 } };

            double correctResult = 46;
            double result = OurVector.Multiply(va, vb);
            if (result == correctResult)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void MultiplyTest2()
        {
            OurVector va = new OurVector() { basis = { 2, 5 } };
            double scalar = 3;

            OurVector correctResult = new OurVector() { basis = { 6, 15 } };
            OurVector result = OurVector.Multiply(va, scalar);
            if (result.basis[0] == correctResult.basis[0]
                &&
                result.basis[1] == correctResult.basis[1])
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void SubtractTest()
        {
            OurVector va = new OurVector() { basis = { 2, 5 } };
            OurVector vb = new OurVector() { basis = { 3, 8 } };

            OurVector correctResult = new OurVector() { basis = { -1, -3 } };
            OurVector result = OurVector.Subtract(va, vb);
            if (result.basis[0] == correctResult.basis[0]
                &&
                result.basis[1] == correctResult.basis[1])
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void AdditionTest()
        {
            OurVector va = new OurVector() { basis = { 2, 5 } };
            OurVector vb = new OurVector() { basis = { 3, 8 } };

            OurVector correctResult = new OurVector() { basis = { 5, 13 } };
            OurVector result = OurVector.Addition(va, vb);
            if (result.basis[0] == correctResult.basis[0]
                &&
                result.basis[1] == correctResult.basis[1])
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void DivisionTest()
        {
            OurVector va = new OurVector() { basis = { 9, 12 } };
            double scalar = 3;

            OurVector correctResult = new OurVector() { basis = { 3, 4 } };
            OurVector result = OurVector.Division(va, scalar);
            if (result.basis[0] == correctResult.basis[0]
                &&
                result.basis[1] == correctResult.basis[1])
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void LLLAlgorithmTest1()
        {
            var InputVectors = new List<OurVector>()
            {
             new OurVector() {basis = {47, 215}},
             new OurVector() {basis = {95, 460}},
            };

            var OutputVectors = new List<OurVector>()
            {
             new OurVector() {basis = {1, 30}},
             new OurVector() {basis = {40, 5}},
            };

            InputVectors = OurVector.LLLAlgorithm(InputVectors);

            int i = 0;
            foreach (OurVector vector in InputVectors)
            {

                if (!vector.basis.SequenceEqual(OutputVectors[i].basis))
                {
                    Assert.Fail();
                }
                i++;
            }
            return;
        }

        [TestMethod()]
        public void LLLAlgorithmTest2()
        {
            var InputVectors = new List<OurVector>()
            {
             new OurVector() {basis = {201, 37}},
             new OurVector() {basis = {1648, 297}},
            };

            var OutputVectors = new List<OurVector>()
            {
             new OurVector() {basis = {1, 32}},
             new OurVector() {basis = {40, 1}},
            };

            InputVectors = OurVector.LLLAlgorithm(InputVectors);

            int i = 0;
            foreach (OurVector vector in InputVectors)
            {
                
                if (!vector.basis.SequenceEqual(OutputVectors[i].basis))
                {
                    Assert.Fail();
                }
                i++;
            }
            return;
        }

        [TestMethod()]
        public void LLLAlgorithmTest3()
        {
            var InputVectors = new List<OurVector>()
            {
             new OurVector() {basis = {1, 1, 1}},
             new OurVector() {basis = {-1,0, 2}},
             new OurVector() {basis = {3, 5, 6}},
            };

            var OutputVectors = new List<OurVector>()
            {
             new OurVector() {basis = {0, 1, 0}},
             new OurVector() {basis = {1, 0, 1}},
             new OurVector() {basis = {-1,0, 2}},
            };

            InputVectors = OurVector.LLLAlgorithm(InputVectors);

            int i = 0;
            foreach (OurVector vector in InputVectors)
            {

                if (!vector.basis.SequenceEqual(OutputVectors[i].basis))
                {
                    Assert.Fail();
                }
                i++;
            }
            return;
        }
    }
}