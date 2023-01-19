import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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
  constructor(private http: HttpClient) { }

  getList(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(`${environment.apiUrl}/Pessoas`);
  }

  addPessoa(pessoa: any) {
    const body = JSON.stringify(pessoa);
    return this.http.post(`${environment.apiUrl}/Pessoas`, body)
      .subscribe(
        (r) => console.log(r)
      );
  }

  removerPessoa(id: number) {
    return this.http.delete(`${environment.apiUrl}/Pessoas/${id}`)
      .subscribe({
        next: (r) => { console.log('Deu certo...'), window.location.reload() },
        error: (e) => alert(`${e.error}`),
        complete: () => alert('Excluído com sucesso!')
      });
  }

  buscaCep(cep: string) {

    return this.http.get<Pessoa>(`https://viacep.com.br/ws/${cep}/json/`);
  }
}
