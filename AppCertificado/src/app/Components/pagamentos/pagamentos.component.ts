import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PagamentosService } from 'src/app/pagamentos.service';
import { Pagamento } from 'src/app/Pagamento';

@Component({
  selector: 'app-pagamentos',
  templateUrl: './pagamentos.component.html',
  styleUrls: ['./pagamentos.component.css']
})
export class PagamentosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private pagamentosService: PagamentosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Anuncio';
    this.formulario = new FormGroup({
      IdCartao: new FormControl(null),
      NomeTitular: new FormControl(null),
      NumeroCartao: new FormControl(''),
      ValidadeCartao: new FormControl(''),
      CodigoSeguranca: new FormControl(''),
      EnderecoFaturamento: new FormControl(''),
      BancoEmissor: new FormControl(''),
      BandeiraCartao: new FormControl(''),
      CpfTitular: new FormControl(''),
      TelefoneTitular: new FormControl('')
    });
  }

  enviarFormulario(): void {
    const pagamento: Pagamento = this.formulario.value;
    this.pagamentosService.cadastrar(pagamento).subscribe(result => {
      alert('Anuncio inserido com sucesso.');
    })
  }
}
