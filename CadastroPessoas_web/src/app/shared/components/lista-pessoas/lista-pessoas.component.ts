import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Pessoa } from 'src/app/models/pessoa';
import { RequestService } from 'src/app/services/request/request.service';

@Component({
  selector: 'app-lista-pessoas',
  templateUrl: './lista-pessoas.component.html',
  styleUrls: ['./lista-pessoas.component.scss']
})
export class ListaPessoasComponent implements OnInit {

  listaPessoas: Pessoa[] = [];

  constructor(private requestService: RequestService) { }

  ngOnInit(): void {
    this.getLista();
  }

  getLista() {
    this.requestService.getPessoasList()
      .subscribe({
        next: (res) => this.listaPessoas = res
      });
  }

  removerRegistro(id: number) {
    this.requestService.removerPessoa(id);
  }
}
