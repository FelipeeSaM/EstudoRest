using RestAPI.Hypermedia.Abstract;

namespace RestAPI.Hypermedia.Filters {
    public class HyperMediaFilterOptions {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
