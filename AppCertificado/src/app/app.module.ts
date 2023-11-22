import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AnunciosService } from './anuncios.service';
import { AnunciosComponent } from './Components/anuncios/anuncios.component';

import { CertificadorasComponent } from './Components/certificadoras/certificadoras.component';
import { CertificadorasService } from './certificadoras.service';

import { PagamentosService } from './pagamentos.service';
import { PagamentosComponent } from './Components/pagamentos/pagamentos.component';

@NgModule({
  declarations: [
    AppComponent,
    AnunciosComponent,
    CertificadorasComponent,
    PagamentosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [
    AnunciosService,
    CertificadorasService,
    PagamentosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
