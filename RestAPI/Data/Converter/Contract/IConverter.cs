namespace RestAPI.Data.Converter.Contract {
    public interface IConverter<Origem, Destino> {

        /// <summary>
        /// Converte do primeiro "parâmetro" para o segundo.
        /// </summary>
        /// <param name="item">Item a ser mapeado</param>
        /// <returns></returns>
        Destino Converter(Origem item);

        List<Destino> Converter(List<Origem> item);
    }
}