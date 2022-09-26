import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Pessoa } from 'src/app/models/pessoa';

@Component({
  selector: 'app-lista-pessoas',
  templateUrl: './lista-pessoas.component.html',
  styleUrls: ['./lista-pessoas.component.scss']
})
export class ListaPessoasComponent implements OnInit {

  lista: Pessoa[];

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.getLista();
  }

  getLista() {
    this.httpClient.get<Pessoa[]>('https://localhost:44349/Pessoas')
      .subscribe(
        res => this.lista = res
      )
  }

}
