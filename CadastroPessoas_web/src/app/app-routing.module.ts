import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdicionarPessoaComponent } from './pages/adicionar-pessoa/adicionar-pessoa.component';
import { HomeComponent } from './pages/home/home.component';
import { ListaPessoasComponent } from './pages/lista-pessoas/lista-pessoas.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'lista', component: ListaPessoasComponent },
  { path: 'adicionar', component: AdicionarPessoaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
