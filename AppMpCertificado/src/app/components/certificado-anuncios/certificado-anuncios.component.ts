import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CertificadoAnunciosService } from 'src/app/certificado-anuncios.service'; // Caminho relativo ao serviço
import { CertificadoAnuncio } from 'src/app/CertificadoAnuncio'; // Caminho relativo ao modelo

@Component({
  selector: 'app-certificado-anuncios',
  templateUrl: './certificado-anuncios.component.html', 
  styleUrls: ['./certificado-anuncios.component.css']
})


export class CertificadoAnunciosComponent implements OnInit {
  formulario: FormGroup;
  tituloFormulario: string = '';

  constructor(private certificadoAnunciosService: CertificadoAnunciosService) {
    this.tituloFormulario = 'Novo Anúncio de Certificado';
    this.formulario = new FormGroup({
      idCertificadoA: new FormControl(null),
      tipoDeCliente: new FormControl(null),
      tipoDeDispositivo: new FormControl(null),
      fabricante: new FormControl(null),
      idFabricante: new FormControl(null),
      tempoDeValidade: new FormControl(null),
      tipoDeEmissao: new FormControl(null),
      valor: new FormControl(null),
      tipoCertificadoA1A3: new FormControl(null),
      title: new FormControl(null),
    });
  }



  ngOnInit(): void {
    this.tituloFormulario = 'Novo Anúncio de Certificado';
  }

  enviarFormulario(): void {
    const certificadoAnuncio: CertificadoAnuncio = this.formulario.value;
    this.certificadoAnunciosService.cadastrar(certificadoAnuncio).subscribe(result => {
      alert('Anúncio inserido com sucesso.');
    });
  }
}
