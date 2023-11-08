export class CertificadoAnuncio {
  IdCertificadoA: number = 0;
  TipoDeCliente: string = "";
  TipoDeDispositivo: string = "";
  Fabricante: string = "";
  IdFabricante: number = 0;
  TempoDeValidade: string = "";
  TipoDeEmissao: string = "";
  Valor: number = 0;
  TipoCertificadoA1A3: string = ""; // Adicionando a propriedade do tipo de certificado A1 ou A3
  title: any;
}

export default CertificadoAnuncio;
