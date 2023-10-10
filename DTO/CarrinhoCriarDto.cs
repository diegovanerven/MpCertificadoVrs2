namespace MpCertificadoVrs2.Dto
{
    public class CarrinhoCriarDto
    {
        public int ClienteId { get; set; }
        public int CertificadoAnuncioId { get; set; }
        // metodo criado para que quando for criar o carrinho apenas com
        // o id do cliente e do certificadoAnuncio ele ja faça o preenchimento automatico
    }
}
