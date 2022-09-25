import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { ListaPessoasComponent } from './pages/lista-pessoas/lista-pessoas.component';
import { AdicionarPessoaComponent } from './pages/adicionar-pessoa/adicionar-pessoa.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListaPessoasComponent,
    AdicionarPessoaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
