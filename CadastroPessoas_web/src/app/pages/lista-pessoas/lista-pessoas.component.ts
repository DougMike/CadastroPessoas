import { Component, OnInit } from '@angular/core';
import { Pessoa } from 'src/app/models/pessoa';

@Component({
  selector: 'app-lista-pessoas',
  templateUrl: './lista-pessoas.component.html',
  styleUrls: ['./lista-pessoas.component.scss']
})
export class ListaPessoasComponent implements OnInit {

  lista: Pessoa[] = [{
    nome: 'teste',
    sobrenome: 'teste',
    cidade: 'tetse',
    cep: 'teste',
    email: 'teste',
    estado: 'teste',
    logradouro: 'teste',
    nacionalidade: 'teste',
    telefone: 'teste',
  }];

  constructor() { }

  ngOnInit(): void {
  }

}
