import { Component, OnInit } from '@angular/core';
import { Pessoa } from 'src/app/models/pessoa';
import { RequestService } from 'src/app/services/request.service';

@Component({
  selector: 'app-lista-pessoas',
  templateUrl: './lista-pessoas.component.html',
  styleUrls: ['./lista-pessoas.component.scss']
})
export class ListaPessoasComponent implements OnInit {

  lista: Pessoa[];

  constructor(private request: RequestService) { }

  ngOnInit(): void {
    this.getLista();
  }

  async getLista(){
    this.lista = await this.request.getList();
  }

}
