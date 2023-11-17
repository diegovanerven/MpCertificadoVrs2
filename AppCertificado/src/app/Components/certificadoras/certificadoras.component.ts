import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CertificadorasService } from 'src/app/certificadoras.service';
import { Certificadora } from 'src/app/Certificadora';

@Component({
  selector: 'app-certificadoras',
  templateUrl: './certificadoras.component.html',
  styleUrls: ['./certificadoras.component.css']
})
export class CertificadorasComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private certificadorasService: CertificadorasService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Certificadora';
    this.formulario = new FormGroup({
      IdCertificadora: new FormControl(null),
      NomeCertificadora: new FormControl(null),
      CNPJ: new FormControl(''),
      Telefone: new FormControl(''),
      email: new FormControl(''),
      NumeroInmetro: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    const certificadora: Certificadora = this.formulario.value;
    this.certificadorasService.cadastrar(certificadora).subscribe(result => {
      alert('Certificadora cadastrada com sucesso!');
    });
  }
}
