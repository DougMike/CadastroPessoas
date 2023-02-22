import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { ListaPessoasComponent } from './shared/components/lista-pessoas/lista-pessoas.component';
import { AdicionarPessoaComponent } from './pages/adicionar-pessoa/adicionar-pessoa.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgxMaskModule, IConfig } from 'ngx-mask'
import { InterceptorService } from './services/request/interceptors/interceptor.service';
import { NavBarComponent } from './shared/components/nav-bar/nav-bar.component';
import { FileComponent } from './pages/arquivos/file.component';
import { ListFilesComponent } from './pages/arquivos/list-files/list-files.component';
import { ImportFileComponent } from './pages/arquivos/import-file/import-file.component';

export const options: Partial<null | IConfig> | (() => Partial<IConfig>) = null;

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListaPessoasComponent,
    AdicionarPessoaComponent,
    NavBarComponent,
    FileComponent,
    ListFilesComponent,
    ImportFileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgxMaskModule.forRoot(),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
