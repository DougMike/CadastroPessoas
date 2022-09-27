import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  endereco: any;
  constructor(private http: HttpClient) { }

  buscaCep(cep: string) {
     this.http.get<any>(`https://viacep.com.br/ws/${cep}/json/`)
      .subscribe(
        res => this.endereco = res
      );
      return this.endereco;
  }
}
