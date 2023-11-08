import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { CertificadoAnuncioService } from 'src/app/certificado-anuncio.service';
import { CertificadoAnuncio } from 'src/app/CertificadoAnuncio';

@Component({
  selector: 'app-certificado-anuncio',
  templateUrl: './certificado-anuncio.component.html',
  styleUrls: ['./certificado-anuncio.component.css']
})
export class CertificadoAnuncioComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private certificadoAnuncioService: CertificadoAnuncioService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Certificado de Anúncio';
    this.formulario = new FormGroup({
      descricao: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    const certificadoAnuncio: CertificadoAnuncio = this.formulario.value;
    this.certificadoAnuncioService.cadastrar(certificadoAnuncio).subscribe((result: any) => {
      alert('Certificado de Anúncio inserido com sucesso.');
    });
  }

}
