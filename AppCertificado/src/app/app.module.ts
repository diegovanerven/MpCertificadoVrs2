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

@NgModule({
  declarations: [
    AppComponent,
    AnunciosComponent  // Corrigido o nome do componente para 'AnunciosComponent'
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [AnunciosService],  // Removido HttpClientModule dos provedores
  bootstrap: [AppComponent]
})
export class AppModule { }
