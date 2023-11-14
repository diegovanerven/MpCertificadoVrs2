import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CertificadoAnunciosService } from 'C:/Users/diego/source/repos/MpCertificadoVrs2/AppMpCertificado/src/app/certificado-anuncios.service';
import { CertificadoAnuncio } from 'C:/Users/diego/source/repos/MpCertificadoVrs2/AppMpCertificado/src/app/CertificadoAnuncio'; // Ajuste no caminho

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
      descricao: new FormControl(null)
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
