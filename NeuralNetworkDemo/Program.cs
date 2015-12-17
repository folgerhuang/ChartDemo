using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Neuro;
using Accord.Neuro.ActivationFunctions;
using Accord.Neuro.Layers;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;
using Accord.Neuro.Neurons;



namespace NeuralNetworkDemo
{
    class Program
    {

       
        static void Main(string[] args)
        {
            double[][] inputs =
            {
                new double[] { 1,1,1, 0,0,0 }, // class a
                new double[] { 1,0,1, 0,0,0 }, // class a
                new double[] { 1,1,1, 0,0,0 }, // class a
                new double[] { 0,0,1, 1,1,0 }, // class b
                new double[] { 0,0,1, 1,0,0 }, // class b
                new double[] { 0,0,1, 1,1,0 }, // class b
            };


            double[][] outputs =
            {
                new double[] { 1, 0 }, // indicates the inputs at this
                new double[] { 1, 0 }, // position belongs to class a
                new double[] { 1, 0 },
                new double[] { 0, 1 }, // indicates the inputs at this
                new double[] { 0, 1 }, // position belongs to class b
                new double[] { 0, 1 },
            };
            BernoulliFunction function = new BernoulliFunction(alpha:0.4);
            RestrictedBoltzmannMachine rbm = new RestrictedBoltzmannMachine(function, inputsCount: 6, hiddenNeurons:2);
            ContrastiveDivergenceLearning teacher = new ContrastiveDivergenceLearning(rbm)
            {
                Momentum = 0,
                LearningRate = 0.1,
                Decay = 0
            };
            for (int i = 0; i < 5000; i++)
            {
                teacher.RunEpoch(inputs);
               
            }

            Console.WriteLine(" Error: " + teacher.ComputeError(inputs));
            

            double[] a = rbm.Compute(new double[] { 1, 1, 1, 0, 0, 0 });
            double[] b = rbm.Compute(new double[] { 0, 0, 0, 1, 1, 1 }); // { 0.00, 0.99 }


             for (int j = 0; j < a.Count(); j++)
            {
                Console.WriteLine(a[j]+"\n");
            }
            
            // As we can see, the first neuron responds to vectors belonging
            // to the first class, firing 0.99 when we feed vectors which 
            // have 1s at the beginning. Likewise, the second neuron fires 
            // when the vector belongs to the second class.

            // We can also generate input vectors given the classes:
            double[] xa = rbm.GenerateInput(new double[] { 1, 0 }); // { 1, 1, 1, 0, 0, 0 }
            double[] xb = rbm.GenerateInput(new double[] { 0, 1 }); // { 0, 0, 1, 1, 1, 0 }

            // As we can see, if we feed an output pattern where the first neuron
            // is firing and the second isn't, the network generates an example of
            // a vector belonging to the first class. The same goes for the second
            // neuron and the second class.
            Console.ReadKey();
            
        }
    }
}
