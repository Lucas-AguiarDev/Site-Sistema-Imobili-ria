namespace mvImoveis.Models
{
    public class Imoveis
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Descricao {get; set;}
        public int Quartos {get; set;}
        public int Banheiros {get; set;}
        public int Garagem {get; set;}
        public string Cidade {get; set;}
        public string Bairro {get; set;}
        public double Valor {get; set;}
        public string Imagem {get; set;}
    }
}