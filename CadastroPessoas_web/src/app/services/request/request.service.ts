import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { options } from 'src/app/app.module';
import { Pessoa } from 'src/app/models/pessoa';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  pessoas: Pessoa[];
  endereco: any;
  constructor(private http: HttpClient,
    private router: Router) { }

  getPessoasList(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(`${environment.apiUrl}/Pessoas`);
  }

  getFileList() {
    return this.http.get<File[]>(`${environment.apiUrl}/api/File`);
  }

  postFile(file: File) {
    return this.http.post<File>(`${environment.apiUrl}/api/File`, file)
      .subscribe({
        next: (f) => console.log(f),
        error: (e) => console.log(e)
      })
  }

  addPessoa(pessoa: any) {

    return this.http.post<any>(`${environment.apiUrl}/Pessoas`, pessoa)
      .subscribe({
        next: (r) => { console.log(r), this.router.navigate(['']) },
        error: (e) => { alert(e.error) }
      });

  }

  removerPessoa(id: any) {
    return this.http.delete(`${environment.apiUrl}/Pessoas/${id}`)
      .subscribe({
        next: (r) => window.location.reload(),
        error: (e) => { console.log('Erro: ', e.error) }
      });
  }

  buscaCep(cep: string) {

    return this.http.get<Pessoa>(`https://viacep.com.br/ws/${cep}/json/`);
  }
}
