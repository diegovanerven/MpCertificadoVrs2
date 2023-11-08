interface CertificadoAnuncio {
  IdCertificadoA: number;
  TipoDeCliente: string;
  TipoDeDispositivo: string;
  Fabricante: string;
  IdFabricante: number;
  TempoDeValidade: string;
  TipoDeEmissao: string;
  Valor: number;
  TipoCertificadoA1A3: string; // Adicionando a propriedade do tipo de certificado A1 ou A3
}

export default CertificadoAnuncio;
