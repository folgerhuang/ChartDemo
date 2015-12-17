using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training;
using Encog.Engine.Network.Activation;
using Encog.ML.Train;
using Encog.Neural.Networks.Training.Propagation.Resilient;


namespace EncogXOR3_3
{
    class Program
    {

        public static double[][] XOR_INPUT ={
            new double[2] { 0.0, 0.0 },
            new double[2] { 1.0, 0.0 },
			new double[2] { 0.0, 1.0 },
            new double[2] { 1.0, 1.0 } };

        /// <summary>
        /// Ideal output for the XOR function.
        /// </summary>
        public static double[][] XOR_IDEAL = {                                              
            new double[1] { 0.0 }, 
            new double[1] { 1.0 }, 
            new double[1] { 1.0 }, 
            new double[1] { 0.0 } };
        static void Main(string[] args)
        {     
            var network = new BasicNetwork();
            network.AddLayer(new BasicLayer(null, true, 2));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(),true,2));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(),false,1));
            network.Structure.FinalizeStructure();
            network.Reset();


            IMLDataSet trainingSet = new BasicMLDataSet(XOR_INPUT, XOR_IDEAL);
            IMLTrain train = new ResilientPropagation(network,trainingSet);
            int epoch=0;
            do
            {
                train.Iteration();
                Console.WriteLine(@"Epoch#" + epoch + @" Error:" + train.Error);
                epoch++;
            } while (train.Error > 0.000001);
           // train.finishTraining();
            Console.WriteLine(@"Neural NetWork Results:");
            foreach(IMLDataPair pair in trainingSet)
            {
                IMLData output = network.Compute(pair.Input);
                Console.WriteLine(pair.Input[0] + @"," + pair.Input[1] + @", actual=" + output[0] + @",ideal=" + pair.Ideal[0]);
            }
            Console.ReadKey();
        }
    }
}
