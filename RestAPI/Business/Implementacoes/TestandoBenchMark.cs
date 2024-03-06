using BenchmarkDotNet.Attributes;
using System.Text;

namespace RestAPI.Business.Implementacoes {
    [RankColumn]
    [MemoryDiagnoser]
    public class TestandoBenchMark {
        int NumeroDeItens = 1000;

        [Benchmark]
        public string ConcatenandoStringsStringBuilder() {
            var sb = new StringBuilder();
            for(int i = 0; i < NumeroDeItens; i++) {
                sb.Append("Macoratti.net_" + i);
            }
            return sb.ToString();
        }

        [Benchmark]
        public string ConcatenandoStringsGenericList() {
            var list = new List<string>(NumeroDeItens);
            for(int i = 0; i < NumeroDeItens; i++) {
                list.Add("Macoratti.net_" + i);
            }
            return list.ToString();
        }
    }
}
