import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';


import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { CertificadoAnunciosService } from './certificado-anuncios.service';
import { CertificadoAnunciosComponent } from './components/certificado-anuncios/certificado-anuncios.component';

@NgModule({
       declarations: [
      // AppComponent,
     CertificadoAnunciosComponent,
     ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
  ],
  providers: [HttpClientModule, CertificadoAnunciosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
