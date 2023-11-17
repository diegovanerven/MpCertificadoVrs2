import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnunciosComponent } from './Components/anuncios/anuncios.component';
import { CertificadorasComponent } from './Components/certificadoras/certificadoras.component';
import { PagamentosComponent } from './Components/pagamentos/pagamentos.component';

const routes: Routes = [
  { path: 'anuncios', component: AnunciosComponent },
  { path: 'certificadoras', component: CertificadorasComponent },  // Adicionado
  { path: 'pagamentos', component: PagamentosComponent }  // Adicionado
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
