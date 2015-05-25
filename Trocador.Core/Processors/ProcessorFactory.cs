using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.Processors {

    public static class ProcessorFactory {

        public static AbstractProcessor Create(int changeAmountInCents) {

            List<AbstractProcessor> processorList = new List<AbstractProcessor>();

            processorList.Add(new BillProcessor());
            processorList.Add(new CoinProcessor());
            processorList.Add(new SilverProcessor());

            // Adicionar novos processadores acima desta linha.

            //Ordenar os processadores pelo maior valor minimo do processador.
            processorList = processorList.OrderByDescending(x => x.MoneyValues.Min()).ToList();

            //Retorna o processador com o maior valor minimo que ainda é menor que o troco a ser dado.  
            return processorList.FirstOrDefault(x => x.MoneyValues.Min() < changeAmountInCents);
        }
    }
}
