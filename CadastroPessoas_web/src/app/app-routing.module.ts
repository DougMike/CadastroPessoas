import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdicionarPessoaComponent } from './pages/adicionar-pessoa/adicionar-pessoa.component';
import { FileComponent } from './pages/arquivos/file.component';
import { ImportFileComponent } from './pages/arquivos/import-file/import-file.component';
import { ListFilesComponent } from './pages/arquivos/list-files/list-files.component';


import { HomeComponent } from './pages/home/home.component';
import { ListaPessoasComponent } from './shared/components/lista-pessoas/lista-pessoas.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'lista', component: ListaPessoasComponent },
  {
    path: 'files', component: FileComponent
    , children: [
      { path: '', redirectTo: 'files', pathMatch: 'full' },
      { path: 'list-files', component: ListFilesComponent },
      { path: 'import-files', component: ImportFileComponent }
    ]
  },
  { path: 'adicionar', component: AdicionarPessoaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
