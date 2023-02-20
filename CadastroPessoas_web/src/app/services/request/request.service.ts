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

  getList(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(`${environment.apiUrl}/Pessoas`);
  }

  addPessoa(pessoa: any) {

    return this.http.post<any>(`${environment.apiUrl}/Pessoas`, pessoa)
      .subscribe({
        next: (r) => { console.log(r), this.router.navigate(['']) },
        error: (e) => { alert(e.error) }
      });

  }

  removerPessoa(id: number) {
    return this.http.delete(`${environment.apiUrl}/Pessoas/${id}`)
      .subscribe({
        next: (r) => this.getList() ,
        error: (e) => { console.log('Erro: ', e) }
      });
  }

  buscaCep(cep: string) {

    return this.http.get<Pessoa>(`https://viacep.com.br/ws/${cep}/json/`);
  }
}
