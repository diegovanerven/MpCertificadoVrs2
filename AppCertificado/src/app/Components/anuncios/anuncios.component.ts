import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AnunciosService } from 'src/app/anuncios.service';
import { Anuncio } from 'src/app/Anuncio';

@Component({
  selector: 'app-anuncios',
  templateUrl: './anuncios.component.html',
  styleUrls: ['./anuncios.component.css'] 
})
export class AnunciosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private anunciosService: AnunciosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Anuncio';
    this.formulario = new FormGroup({
      IdCertificadoA: new FormControl(null),
      Descricao: new FormControl(null),
      TipoDeCliente: new FormControl(''),
      TipoDeDispositivo: new FormControl(''),
      Fabricante: new FormControl(''),
      IdFabricante: new FormControl(null),
      TempoDeValidade: new FormControl(''),
      TipoDeEmissao: new FormControl(''),
      Valor: new FormControl(0)
    })
  }
  enviarFormulario(): void {
    const anuncio: Anuncio = this.formulario.value;
    this.anunciosService.cadastrar(anuncio).subscribe(result => {
      alert('Anuncio inserido com sucesso.');
    })
  }
}
