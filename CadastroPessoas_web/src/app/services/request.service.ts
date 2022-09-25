import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Pessoa } from '../models/pessoa';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  data: Pessoa[];
  constructor(private http: HttpClient) { }

  getList() {
    this.http.get<Pessoa[]>(environment.apiUrl + 'Pessoas')
      .subscribe({
        next: res => this.data = res,
        error: res => console.log(res)
      })
      console.log(this.data)
      return this.data;
  }
}
