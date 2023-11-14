import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CertificadoAnunciosComponent } from './components/certificado-anuncios/certificado-anuncios.component';


const routes: Routes = [
  { path: 'certificado-anuncios', component: CertificadoAnunciosComponent },
  // Adicione outras rotas conforme necessário
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
