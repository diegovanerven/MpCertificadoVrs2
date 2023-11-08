import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { CertificadoAnuncioService } from './certificado-anuncio.service';
import { CertificadoAnuncioComponent } from './components/certificado-anuncio/certificado-anuncio.component';

// Importe os módulos de roteamento
import { RouterModule, Routes } from '@angular/router';

// Defina as rotas
const routes: Routes = [
  { path: 'Certificados', component: CertificadoAnuncioComponent }, // Exemplo de rota case-sensitive
  // Adicione outras rotas conforme necessário
];

@NgModule({
  declarations: [
    AppComponent,
    CertificadoAnuncioComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    // Importe e configure o RouterModule com as rotas
    RouterModule.forRoot(routes)
  ],
  providers: [CertificadoAnuncioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
