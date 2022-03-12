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
        public void SwapWorkingVectorsTest1()
        {
            var StartingVectors = new List<Vector>()
            {
             new Vector() {basis = {47, 215}},
             new Vector() {basis = {95, 460}},
            };

            var CorrectVectors = new List<Vector>()
            {
             new Vector() {basis = {95, 460}},
             new Vector() {basis = {47, 215}},
            };

            Vector.SwapWorkingVectors(StartingVectors, 1);


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
        public void SwapWorkingVectorsTest2()
        {
            var StartingVectors = new List<Vector>()
            {
             new Vector() {basis = {47, 215}},
             new Vector() {basis = {95, 460}},
             new Vector() {basis = {5, 42}},
            };

            var CorrectVectors = new List<Vector>()
            {
             new Vector() {basis = {47, 215}},
             new Vector() {basis = {5, 42}},
             new Vector() {basis = {95, 460}},
            };

            Vector.SwapWorkingVectors(StartingVectors, 2);


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
        public void SizeConditionTest1()
        {
            Vector a = new Vector() { basis = { 95, 460 } };
            Vector b = new Vector() { basis = { 47, 215 } };

            double Result = Vector.SizeReductionNumber(a, b);

            if (Result >= 0.5)
            {
                return;
            }
            Assert.Fail("Condition (Result >= 0.5) is not satisfied");
            return;
        }

        [TestMethod()]
        public void SizeConditionTest2()
        {
            Vector a = new Vector() { basis = { 1, 30 } };
            Vector b = new Vector() { basis = { 40, 5 } };

            double Result = Vector.SizeReductionNumber(a, b);

            if (Result < 0.5)
            {
                return;
            }
            Assert.Fail("Condition (Result < 0.5) is not satisfied");
            return;
        }

        
        [TestMethod()]
        public void ModifyVectorTest()
        {
            int k = 1;
            int i = 0;
            double u = 2.33;

            var StartingVectors = new List<Vector>()
            {
             new Vector() {basis = {47, 215}},
             new Vector() {basis = {95, 460}},
            };

            Vector result = Vector.ModifyVector(StartingVectors[k], StartingVectors, i,u);
            Vector correctResult = new Vector() { basis = { 1, 30 } };

            if (correctResult.basis.SequenceEqual(result.basis))
            {
                return;
            }
            Assert.Fail("Calculated vector and correct vector do not match");
        }

        [TestMethod()]
        public void LovasvConditionTest1()
        {
            Vector Ga = new Vector() { basis = { 47, 215 } };
            Vector Gb = new Vector() { basis = { -5.3, 1.16 } };
            double u = 0.13414130569434696;

            bool result = Vector.LovasvCondition(Ga, Gb, u);
            bool expectedResult = false;

            if (result == expectedResult)
            {
                return;
            }
            Assert.Fail("Condition failed - should be false but was true");
        }

        [TestMethod()]
        public void LovasvConditionTest2()
        {
            Vector Ga = new Vector() { basis = { 1, 30 } };
            Vector Gb = new Vector() { basis = { 39.79, -1.33 } };
            double u = 0.21087680355160932;

            bool result = Vector.LovasvCondition(Ga, Gb, u);
            bool expectedResult = true;

            if (result == expectedResult)
            {
                return;
            }

            Assert.Fail("Condition failed - should be true but was false");
        }

        [TestMethod()]
        public void MultiplyTest1()
        {
            Vector va = new Vector() { basis = { 2, 5 } };
            Vector vb = new Vector() { basis = { 3, 8 } };

            double correctResult = 46;
            double result = va* vb;
            if (result == correctResult)
            {
                return;
            }
            Assert.Fail(result.ToString() + " does not match " + correctResult.ToString());
        }

        [TestMethod()]
        public void MultiplyTest2()
        {
            Vector va = new Vector() { basis = { 2, 5 } };
            double scalar = 3;

            Vector correctResult = new Vector() { basis = { 6, 15 } };
            Vector result = va* scalar;
            
            if (correctResult.basis.SequenceEqual(result.basis))
            {
                return;
            }
            Assert.Fail(result.ToString() + " does not match " + correctResult.ToString());
        }

        [TestMethod()]
        public void SubtractTest()
        {
            Vector va = new Vector() { basis = { 2, 5 } };
            Vector vb = new Vector() { basis = { 3, 8 } };

            Vector correctResult = new Vector() { basis = { -1, -3 } };
            Vector result = va+ (-1*vb);
            
            if (correctResult.basis.SequenceEqual(result.basis))
            {
                return;
            }
            Assert.Fail(result.ToString() + " does not match " + correctResult.ToString());
        }

        [TestMethod()]
        public void AdditionTest()
        {
            Vector va = new Vector() { basis = { 2, 5 } };
            Vector vb = new Vector() { basis = { 3, 8 } };

            Vector correctResult = new Vector() { basis = { 5, 13 } };
            Vector result = va+ vb;
            
            if (correctResult.basis.SequenceEqual(result.basis))
            {
                return;
            }
            Assert.Fail(result.ToString() + " does not match " + correctResult.ToString());
        }

        [TestMethod()]
        public void DivisionTest()
        {
            Vector va = new Vector() { basis = { 9, 12 } };
            double scalar = 3;

            Vector correctResult = new Vector() { basis = { 3, 4 } };
            Vector result = va * (1/scalar);
            

                if (correctResult.basis.SequenceEqual(result.basis))
                {
                return;
                }
                Assert.Fail(result.ToString() + " does not match " + correctResult.ToString());

        }
        

        [TestMethod()]
        public void LLLAlgorithmTest1()
        {
            var InputVectors = new List<Vector>()
            {
             new Vector() {basis = {47, 215}},
             new Vector() {basis = {95, 460}},
            };

            var OutputVectors = new List<Vector>()
            {
             new Vector() {basis = {1, 30}},
             new Vector() {basis = {40, 5}},
            };

            InputVectors = Vector.LLLAlgorithm(InputVectors);

            int i = 0;
            foreach (Vector vector in InputVectors)
            {

                if (!vector.basis.SequenceEqual(OutputVectors[i].basis))
                {
                    Assert.Fail(vector.ToString() + " does not match " + OutputVectors[i].ToString());
                }
                i++;
            }
            return;
        }

        [TestMethod()]
        public void LLLAlgorithmTest2()
        {
            var InputVectors = new List<Vector>()
            {
             new Vector() {basis = {201, 37}},
             new Vector() {basis = {1648, 297}},
            };

            var OutputVectors = new List<Vector>()
            {
             new Vector() {basis = {1, 32}},
             new Vector() {basis = {40, 1}},
            };

            InputVectors = Vector.LLLAlgorithm(InputVectors);

            int i = 0;
            foreach (Vector vector in InputVectors)
            {
                
                if (!vector.basis.SequenceEqual(OutputVectors[i].basis))
                {
                    Assert.Fail(vector.ToString() + " does not match " + OutputVectors[i].ToString());
                }
                i++;
            }
            return;
        }

        [TestMethod()]
        public void LLLAlgorithmTest3()
        {
            var InputVectors = new List<Vector>()
            {
             new Vector() {basis = {1, 1, 1}},
             new Vector() {basis = {-1,0, 2}},
             new Vector() {basis = {3, 5, 6}},
            };

            var OutputVectors = new List<Vector>()
            {
             new Vector() {basis = {0, 1, 0}},
             new Vector() {basis = {1, 0, 1}},
             new Vector() {basis = {-1,0, 2}},
            };

            InputVectors = Vector.LLLAlgorithm(InputVectors);

            int i = 0;
            foreach (Vector vector in InputVectors)
            {

                if (!vector.basis.SequenceEqual(OutputVectors[i].basis))
                {
                    Assert.Fail(vector.ToString() + " does not match " + OutputVectors[i].ToString());
                }
                i++;
            }
            return;
        }


        [TestMethod()]
        public void LLLAlgorithmTest4()
        {
            var InputVectors = new List<Vector>()
            {
             new Vector() {basis = {15, 23, 11}},
             new Vector() {basis = {46,15, 3}},
             new Vector() {basis = {32, 1, 1}},
            };

            var OutputVectors = new List<Vector>()
            {
             new Vector() {basis = {1, 9, 9}},
             new Vector() {basis = {13, 5, -7}},
             new Vector() {basis = {6, -9, 15}},
            };

            InputVectors = Vector.LLLAlgorithm(InputVectors);

            int i = 0;
            foreach (Vector vector in InputVectors)
            {

                if (!vector.basis.SequenceEqual(OutputVectors[i].basis))
                {
                    Assert.Fail(vector.ToString() + " does not match " + OutputVectors[i].ToString());
                }
                i++;
            }
            return;
        }

    }
}