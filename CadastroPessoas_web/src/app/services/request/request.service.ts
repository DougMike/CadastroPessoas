import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Pessoa } from 'src/app/models/pessoa';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  pessoas: Pessoa[];
  endereco: any;
  constructor(private http: HttpClient) { }

  getList(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(environment.dbjson);
  }

  addPessoa(pessoa: any) {
    const body = JSON.stringify(pessoa);
    return this.http.post(environment.dbjson, pessoa)
      .subscribe(() => {
        alert('Adicionado com sucesso!');
        window.location.reload();
      });
  }

  buscaCep(cep: string) {
    return this.http.get<Pessoa>(`https://viacep.com.br/ws/${cep}/json/`);
  }
}
