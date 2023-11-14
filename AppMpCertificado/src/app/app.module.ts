import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';


// Defina as rotas
const routes: Routes = [
  { path: 'Certificados', component: CertificadoAnuncioComponent }, // Exemplo de rota case-sensitive
  // Adicione outras rotas conforme necessário
];

@NgModule({
  declarations: [
      // AppComponent,
     CertificadoAnunciosComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
  ],
  providers: [CertificadoAnuncioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
